
using System;
using System.Collections.Generic;
using System.Linq;
using FrederickNguyen.DomainCore.Models;

namespace FrederickNguyen.DomainLayer.AggregatesModels.Carts.Models
{
    /// <summary>
    /// Enum CheckOutIssue
    /// </summary>
    public class CheckOutIssue : Enumeration
    {
        public static CheckOutIssue UnpaidBalance = new CheckOutIssue(101, nameof(UnpaidBalance).ToLowerInvariant());
        public static CheckOutIssue ProductNotInStock = new CheckOutIssue(201, nameof(ProductNotInStock).ToLowerInvariant());
        public static CheckOutIssue ProductIsFaulty = new CheckOutIssue(202, nameof(ProductIsFaulty).ToLowerInvariant());

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckOutIssue"/> class.
        /// </summary>
        protected CheckOutIssue()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckOutIssue"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        public CheckOutIssue(int id, string name)
            : base(id, name)
        {
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>IEnumerable&lt;CheckOutIssue&gt;.</returns>
        public static IEnumerable<CheckOutIssue> List() => new[] { UnpaidBalance, ProductNotInStock, ProductIsFaulty };

        /// <summary>
        /// Froms the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>CheckOutIssue.</returns>
        public static CheckOutIssue FromName(string name)
        {
            var state = List().SingleOrDefault(s => string.Equals(s.Name, name, StringComparison.CurrentCultureIgnoreCase));
            return state;
        }

        /// <summary>
        /// Froms the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>CheckOutIssue.</returns>
        public static CheckOutIssue From(int id)
        {
            var state = List().SingleOrDefault(s => s.Id == id);
            return state;
        }
    }
}
