namespace DemoScopedDI
{
    public class ScopedDependency
    {        
        public void Run()
        {
            Runs += 1;
        }

        public int Runs { get; private set; } = 0;

        public int Hash => this.GetHashCode();
    }   
}