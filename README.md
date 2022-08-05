# AsynchronousCSharpCode

So you might be wondering if there are any best practices in choosing the synchronization object. And in fact, 
there are your advice to always use the private field as a synchronization object.

The reason for this is simple. Consider for a moment that you lock on a public field now because the field is public, another threat could also lock on that same field.

Now, suddenly you have an unexpected dependency between two threads that might lead to both threads blocking and waiting for each other.

This came easily happen when you always look on the this value. But when you look on a unique private field that you create specifically for the occasion, then you

prevent any other threat to lock on that same object.

So now the unexpected dependency between threads can never happen. It's just another safety net to protect your code from unexpected results.


The long statements INSEE Sharp is syntactic sugar for a monitor.enter and monitor.exit pair and sets up a critical section.

The Monitor class also has a tryenter method that supports a lock timeout value.

The lock statements requires a reference type synchronization object, you can use any object you like, but a unique private object field is recommended.

You can nest lock statements, the critical section is unlocked only when you exit the outermost lock.

Thread synchronization
------------------------
this is the act of synchronizing two or more threads together in order for them to exchange data.

We can generalize this to something more generic threat synchronization is the act of suspending one thread until a certain condition is met in another thread.

If you want to safely pass data between two threads, locking is not enough, you also need to synchronize the threads.

Synchronization can be created using the autoresetevent class.

A call to waitone ()suspends a thread and a call to set() resumes the thread.

For a robust communication channel, you need at least two Autoresetevents with calls to waitone and set at both ends.

Here is a recap of all the topics we covered.
---------------------------------------------------

We looked at how to start a thread and learned that you create threads by calling the thread() constructor and specifying the method to execute.

You can also specify a lambda expression to execute. ()=>{..}

We also saw that threads have names to aid in debugging and that they can be foregrounds or background threads.

An application cannot end until all foreground threads have ended.

We learned that their race condition is a specific problem when program execution no longer follows a predictable path and as a result, code starts behaving in unexpected ways.

Race conditions occur because two or more threads are trying to read and write to the same variable.

A good strategy to minimize race conditions is to keep the data shared between threads to an absolute minimum.

Race conditions can be eliminated by using thread locking.

We learned that you should lock thread's every time when you have two or more threads that are reading and writing the same shared variable.

When locking, you should take care that every variable access and assignment is protected with a critical section.

When you are using compare and assign operations, the entire operation must be embedded in a single critical section.

You should also pull any long running methods out of a critical section to make the section as short as possible.

We learned that the look statements in C Sharp is nothing more than syntactic sugar for a monitor.enter() and Monitor.Exit() pair, and sets up a critical section.

The monitor class also has a tryenter methods that supports a lock timeout value.

lock statements requires a reference type synchronization object. You can use any object you like, but a unique private object field is recommended.

You can also Nest locks statements. The critical section is unlocked when you exit the outermost lock.

We've learned that locking is not enough to safely exchange data between two threads. 
You will also need to synchronize the threads, you can set up threads synchronization with the autoresetevent class.

For a robust communication channel, you need to also reset events with calls to wait one and set at both ends.

Task Parallel Library
--------------------------

when can we use Tasks - Well, any time when you have discrete units of work that can be executed asynchronously and that may or may not return a result to the calling threat.

Tasks are lightweights, abstractions around a single unit of work, and you can create as many as you like, hundreds or thousands of tasks are no problem at all.

Even millions of tasks is possible if you are careful.

So to summarize.

The Task Parallel Library provides a very handy task class for asynchronously, performing a unit of work and returning the results to another thread.

You access the results property when you need the results of the task. The property automatically blocks if a result is not yet available.

Tasks are lightweight abstractions of asynchronous units of work, and you can safely create hundreds or thousands of tasks.


Use the non generic task class for tasks that do not return the result. The wait method blocks until the task has completed.

Use the genetic task class for tasks that do return results. The result property also blocks until the task has completed.

By default, tasks execute on the dot net runtime thread pool. Four long running and i/o bound tasks, you can provide the long running option to execute tem on a non pool thread.

Any exceptions thrown by a task will propagate to the calling code and are automatically re-thrown in the wait methods and the results property.

Tasks can be connected hierarchically and sequentially.

Hierarchical tasks are called parent and child tasks.

A parent's task will not complete until all its child's tasks have completed.

Exceptions and cancellations bubble up from child tasks and are wrapped in an aggregate exception in the parent task.

Tasks can be connected hierarchically and sequentially.

Sequentially connected tasks are called continuations.

Each task in the continuation starts after the previous task in the sequence has completed.

The lambda expression in each continuation can access the results of the previous task.

Continuations are perfect for setting up multithreaded mass-produced processes in C Sharp.

There are three asynchronous frameworks inside sharp.

The Task Parallel Library, The parallel class and the parallel linq library.

The parallel class automatically partitions millions of units of work onto thousands of tasks.

The parallel linq library does this, too, but it's also automatically aggregates the bundles into a final result.

You should use tasks if you have up to 10000 units of work and you do not need automatic mapping or reducing.
