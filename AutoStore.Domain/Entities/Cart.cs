using System.Collections.Generic;
using System.Linq;

namespace AutoStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> list = new List<CartLine>();
        public IEnumerable<CartLine> cartLines { get { return list; } }
        public void AddItem(Auto auto, int quantity)
        {
            CartLine line=list.Where(l=>l.Auto.AutoId== auto.AutoId).FirstOrDefault();
            if (line == null)
            {
                list.Add(new CartLine { Auto = auto, Quantity = quantity });
            }
            else
            {
                line.Quantity+= quantity;
            }
        }
        public void RemoveLine(Auto auto)
        {
            CartLine item = list.Find(m => m.Auto.AutoId == auto.AutoId);
            if (item != null)
            {
                list.Remove(item);
            }
        }
        public decimal SumTovar()
        {
            return list.Sum(s => s.Auto.Price * s.Quantity);
        }
        public void ClearList()
        {
            list.Clear();
        }
    }
    public class CartLine
    {
        public Auto Auto { get; set; }
        public int Quantity { get; set; }
    }
}
