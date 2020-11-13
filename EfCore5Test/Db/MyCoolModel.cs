namespace EfCore5Test.Db
{
    public class MyCoolModel
    {
        public MyCoolModel() => Id = new MyCoolKey();

        public int FirstId { get => Id.FirstId; set => Id.FirstId = value; }

        public virtual FirstModel First { get; set; }
        public virtual SecondModel Second { get; set; }

        public int SecondId { get => Id.SecondId; set => Id.SecondId = value; }

        public MyCoolKey Id { get; set; }

        public string SomeText { get; set; }
    }

    public class MyCoolKey
    {
        public int FirstId { get; set; }
        public int SecondId { get; set; }
    }

    public class FirstModel
    {
        public int Id
        {
            get; set;
        }
    }

    public class SecondModel
    {
        public int Id
        {
            get; set;
        }
    }
}
