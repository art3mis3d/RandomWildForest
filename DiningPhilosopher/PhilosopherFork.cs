namespace DiningPhilosopher;

public class PhilosopherFork
{
    private readonly bool[] _fork = new bool[5];

    public void Get(int left, int right)
    {
        lock (this)
        {
            while (_fork[left] && _fork[right])
                Monitor.Wait(this);
            
            _fork[left] = true;
            _fork[right] = true;
        }
    }

    public void Put(int left, int right)
    {
        lock (this)
        {
            _fork[left] = false; _fork[right] = false;
            Monitor.PulseAll(this);
        }
    }
}