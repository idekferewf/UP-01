namespace AptekaEuLib.products
{
    public class Category
    {
        private int id_;

        public int Id { get { return id_; } }

        public string Name { get; set; }

        public Category(int id)
        {
            id_ = id;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
