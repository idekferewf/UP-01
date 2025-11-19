namespace AptekaEuLib.supplies
{
    public class Supplier
    {
        private string tin_;

        public string Tin { get {  return tin_; } }

        public string Name;

        public string ContactPerson;

        public string Phone;

        public string Address;

        public Supplier(string tin)
        {
            tin_ = tin;
        }
    }
}