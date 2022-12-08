namespace DiningPhilosopher;

public class Philosopher
{
    private int n;           
    private int thinkDelay;  
    private int eatDelay;    
    private int left, right; 
    private PhilosopherFork philosopherFork;     
    public Philosopher(int n, int thinkDelay, int eatDelay, PhilosopherFork philosopherFork)
    {
        this.n = n;
        this.thinkDelay = thinkDelay; this.eatDelay = eatDelay;
        this.philosopherFork = philosopherFork;
        left = (n == 0 ? 4 : n - 1);
        right = (n + 1) % 5;
        new Thread(Run).Start();
    }

    private void Run()
    {
        for (; ; )
        {
            try
            {
                Thread.Sleep(thinkDelay);
                philosopherFork.Get(left, right);
                Console.WriteLine("Philosopher " + n + " is eating...");
                Console.ReadLine();
                Thread.Sleep(eatDelay);
                philosopherFork.Put(left, right);
            }
            catch
            {
                return;
            }
        }
    }
}