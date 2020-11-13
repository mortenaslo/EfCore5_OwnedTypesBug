using System.ComponentModel.DataAnnotations.Schema;

namespace EfCore5Test.Db
{
    [Table("my_cools", Schema = "cool_stuff")]
    public class MyCoolModel
    {
        public MyCoolModel() => Id = new MyCoolKey();

        public int FirstId { get => Id.FirstId; set => Id.FirstId = value; }

        //public int SecondId { get => Id.SecondId; set => Id.SecondId = value; }

        public MyCoolKey Id { get; set; }

        public string SomeText { get; set; }
    }

    public class MyCoolKey
    {
        public int FirstId { get; set; }
        public int SecondId { get; set; }
    }
}
