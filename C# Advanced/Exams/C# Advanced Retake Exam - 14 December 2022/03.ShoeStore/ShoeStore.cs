using System.Text;
using System.Threading.Channels;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> Shoes;
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }

        public int Count => Shoes.Count();

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            Shoes.Add(shoe);

            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }
        public int RemoveShoes(string material)
        {
            return Shoes.RemoveAll(shoe => string.Equals(shoe.Material, material, StringComparison.OrdinalIgnoreCase));
        }

        public List<Shoe> GetShoesByType(string type)
        {
            return Shoes.Where(shoe => shoe.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Shoe GetShoeBySize(double size)
        {
            return Shoes.FirstOrDefault(s => s.Size == size);
        }

        public string StockList(double size, string type)
        {
            var machingShoes = Shoes.Where(s =>
                s.Size == size && s.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
            
            StringBuilder sb = new StringBuilder();

            if (machingShoes.Any())
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (var shoe in machingShoes)
                {
                    sb.AppendLine(shoe.ToString());
                }
            }
            else
            {
                sb.AppendLine("No matches found!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}