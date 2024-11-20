namespace LAB10_lib
{
    public class Place
    {
        private string name = string.Empty;
        public  string Name {
            get { return name; }
            set { name = value; }
        }
        public Place(string name) {
            Name = name;
        }
        public Place() {
            Name = ' '.ToString();
        }
        public Place(Place other)
        {
            Name = other.Name;
        }
        public virtual void Show()
        {
            Console.WriteLine(Name);
        }
        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            Place other = (Place)obj;
            return Name == other.Name;
        }

    }
}
