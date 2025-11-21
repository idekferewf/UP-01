namespace AptekaEuLib.supplies
{
    public class Supplier
    {
        private string tin_;

        public string Tin { get {  return tin_; } }

        public string Name { get; set; }

        public string ContactPerson { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public Supplier(string tin)
        {
            tin_ = tin;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}