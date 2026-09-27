using System.Collections.Generic;
using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private List< Product > _products;
        private Customer _customer;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List< Product >();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal totalProductCost = 0;
            foreach (Product product in _products)
            {
                totalProductCost += product.GetTotalCost();
            }

            decimal shippingCost = _customer.IsInUSA() ? 5.00m : 35.00m;
            return totalProductCost + shippingCost;
        }

        public string GetPackingLabel()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PACKING LABEL:");
            foreach (Product product in _products)
            {
                sb.AppendLine($"  - {product.GetName()} (ID: {product.GetProductId()})");
            }
            return sb.ToString().TrimEnd();
        }

        public string GetShippingLabel()
        {
            return $"SHIPPING LABEL:\n{_customer.GetName()}\n{_customer.GetAddress().GetFormattedAddress()}";
        }
    }
}