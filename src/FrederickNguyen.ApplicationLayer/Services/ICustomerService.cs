// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 06-19-2018
//
// Last Modified By : thangnd
// Last Modified On : 06-19-2018
// ***********************************************************************
// <copyright file="ICustomerAppService.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using FrederickNguyen.ApplicationLayer.DataTransferObjects;
using FrederickNguyen.ApplicationLayer.Models;

namespace FrederickNguyen.ApplicationLayer.Services
{
    /// <summary>
    /// Interface ICustomerAppService
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Determines whether [is email available] [the specified email].
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns><c>true</c> if [is email available] [the specified email]; otherwise, <c>false</c>.</returns>
        bool IsEmailAvailable(string email);

        /// <summary>
        /// Gets the customer by identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CustomerDto.</returns>
        CustomerDto GetCustomerById(Guid customerId);

        /// <summary>
        /// Gets the customer purchase history.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>CustomerPurchaseHistoryDto.</returns>
        CustomerPurchaseHistoryDto GetCustomerPurchaseHistory(Guid customerId);

        /// <summary>
        /// Adds the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        Task<bool> Add(AddNewCustomerViewModel model);

        /// <summary>
        /// Removes the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        Task<bool> Remove(RemoveCustomerViewModel model);
    }
}
