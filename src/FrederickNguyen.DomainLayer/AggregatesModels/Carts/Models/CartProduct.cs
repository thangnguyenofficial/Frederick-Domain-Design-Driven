
using System;
using FrederickNguyen.DomainLayer.AggregatesModels.Customers.Models;
using FrederickNguyen.DomainLayer.AggregatesModels.Products.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models
{
    /// <summary>
    /// Class CartProduct.
    /// </summary>
    public class CartProduct
    {
        /// <summary>
        /// Gets or sets the cart identifier.
        /// </summary>
        /// <value>The cart identifier.</value>
        public virtual Guid CartId { get; protected set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public virtual int Quantity { get; protected set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public virtual Guid ProductId { get; protected set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public virtual DateTime CreatedDate { get; protected set; }

        /// <summary>
        /// Gets or sets the cost price.
        /// </summary>
        /// <value>The cost price.</value>
        public virtual decimal Cost { get; protected set; }

        /// <summary>
        /// Creates the specified customer.
        /// </summary>
        /// <param name="customer">The customer.</param>
        /// <param name="cart">The cart.</param>
        /// <param name="product">The product.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>CartProduct.</returns>
        public static CartProduct Create(Customer customer, Cart cart, Product product, int quantity)
        {
            var cartProduct = new CartProduct
            {
                CartId = cart.Id,
                ProductId = product.Id,
                Quantity = quantity,
                CreatedDate = DateTime.Now,
                Cost = product.Cost,
            };

            return cartProduct;
        }
    }
}
