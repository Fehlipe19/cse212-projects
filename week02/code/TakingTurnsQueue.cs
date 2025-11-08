using System.Diagnostics;
/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public bool reversed = false;


    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        if (_people.Length > 0)
        {
            Stack<Person> queueStack = new Stack<Person>();
            Stack<Person> reverseStack = new Stack<Person>();

            if (reversed == true)
            {
                while (_people.Length > 0)
                {
                    queueStack.Push(_people.Dequeue());
                }
                queueStack.Push(person);
                while (queueStack.Count > 0)
                {
                    _people.Enqueue(queueStack.Pop());
                }
            }
            // Reverse queue once
            while (reversed == false)
            {
                // Get queue onto a stack(FILO)"(Sue, Tim, Bob)"
                while (_people.Length > 0)
                {
                    queueStack.Push(_people.Dequeue());
                }
                // Reverse the stack order "(Bob, Tim, Sue)"
                while (queueStack.Count > 0)
                {
                    reverseStack.Push(queueStack.Pop());
                }
                // Enqueue new person at beginning of Queue
                _people.Enqueue(person);

                // Requeue the stack in reversed order "(Bob, Tim, Sue)"
                while (reverseStack.Count > 0)
                {
                    _people.Enqueue(reverseStack.Pop());
                }
                reversed = true;
            }

        }
        else
        {
            // Enqueue is adding items to the beginning of the queue instead of the end.
            _people.Enqueue(person);
        }
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }
        else
        {
            //Declare stack to help with requeuing
            Stack<Person> queueStack = new Stack<Person>();
            
            Person person = _people.Dequeue();

            bool reQueued = false;
            if (person.Turns > 1)
            // requeue person
            {
                person.Turns -= 1;
                while (reQueued == false)
                {

                    while (_people.Length > 0)
                    {
                        queueStack.Push(_people.Dequeue());
                    }

                    queueStack.Push(person);

                    while (queueStack.Count > 0)
                    {
                        _people.Enqueue(queueStack.Pop());
                    }
                    reQueued = true;
                }
            }
            else if (person.Turns <= 0)
            {
                while (reQueued == false)
                {
                    while (_people.Length > 0)
                    {
                        queueStack.Push(_people.Dequeue());
                    }

                    _people.Enqueue(person);

                    while (queueStack.Count > 0)
                    {
                        _people.Enqueue(queueStack.Pop());
                    }
                    reQueued = true;
                }
                Debug.WriteLine(_people);
            }
            return person;
        }
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}