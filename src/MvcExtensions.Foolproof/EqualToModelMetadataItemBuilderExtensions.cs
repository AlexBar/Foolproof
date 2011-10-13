#region Copyright
// Copyright (c) 2009 - 2011, Kazi Manzur Rashid <kazimanzurrashid@gmail.com>, hazzik <hazzik@gmail.com>.
// This source is subject to the Microsoft Public License. 
// See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL. 
// All other rights reserved.
#endregion

namespace MvcExtensions
{
    using System;
    using Foolproof;

    /// <summary>
    /// Adds validation for <see cref="EqualToAttribute"/>
    /// </summary>
    public class EqualToModelMetadataItemBuilderExtensions
    {
        /// <summary>
        /// Sets the range of value, this comes into action when is <code>Required</code> is <code>true</code>.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="otherProperty">The other property.</param>
        /// <returns></returns>
        public ModelMetadataItemBuilder<TItem, TItemBuilder> EqualTo<TItem, TItemBuilder>(ModelMetadataItemBuilder<TItem, TItemBuilder> self, string otherProperty)
            where TItem : ModelMetadataItem where TItemBuilder : ModelMetadataItemBuilder<TItem, TItemBuilder>
        {
            return EqualTo(self, otherProperty, null, null, null);
        }

        /// <summary>
        /// Sets the range of value, this comes into action when is <code>Required</code> is <code>true</code>.
        /// </summary>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="self">The instance.</param>
        /// <returns></returns>
        public ModelMetadataItemBuilder<TItem, TItemBuilder> EqualTo<TItem, TItemBuilder>(ModelMetadataItemBuilder<TItem, TItemBuilder> self, string otherProperty, string errorMessage)
            where TItem : ModelMetadataItem
            where TItemBuilder : ModelMetadataItemBuilder<TItem, TItemBuilder>
        {
            return EqualTo(self, otherProperty, () => errorMessage);
        }

        /// <summary>
        /// Sets the range of value, this comes into action when is <code>Required</code> is <code>true</code>.
        /// </summary>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="self">The instance.</param>
        /// <returns></returns>
        public ModelMetadataItemBuilder<TItem, TItemBuilder> EqualTo<TItem, TItemBuilder>(ModelMetadataItemBuilder<TItem, TItemBuilder> self, string otherProperty, Func<string> errorMessage)
            where TItem : ModelMetadataItem
            where TItemBuilder : ModelMetadataItemBuilder<TItem, TItemBuilder>
        {
            return EqualTo(self, otherProperty, errorMessage, null, null);
        }

        /// <summary>
        /// Sets the range of value, this comes into action when is <code>Required</code> is <code>true</code>.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="errorMessageResourceType">Type of the error message resource.</param>
        /// <param name="errorMessageResourceName">Name of the error message resource.</param>
        /// <returns></returns>
        public ModelMetadataItemBuilder<TItem, TItemBuilder> EqualTo<TItem, TItemBuilder>(ModelMetadataItemBuilder<TItem, TItemBuilder> self, string otherProperty, Type errorMessageResourceType, string errorMessageResourceName)
            where TItem : ModelMetadataItem
            where TItemBuilder : ModelMetadataItemBuilder<TItem, TItemBuilder>
        {
            return EqualTo(self, otherProperty, null, errorMessageResourceType, errorMessageResourceName);
        }

        /// <summary>
        /// Sets the range of value, this comes into action when is <code>Required</code> is <code>true</code>.
        /// </summary>
        /// <param name="self">The instance.</param>
        /// <param name="otherProperty">The other property.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="errorMessageResourceType">Type of the error message resource.</param>
        /// <param name="errorMessageResourceName">Name of the error message resource.</param>
        /// <returns></returns>
        protected virtual ModelMetadataItemBuilder<TItem, TItemBuilder> EqualTo<TItem, TItemBuilder>(ModelMetadataItemBuilder<TItem, TItemBuilder> self, string otherProperty, Func<string> errorMessage, Type errorMessageResourceType, string errorMessageResourceName)
            where TItem : ModelMetadataItem
            where TItemBuilder : ModelMetadataItemBuilder<TItem, TItemBuilder>
        {
            var validation = self.Item.GetValidationOrCreateNew<EqualToAttributeMetadata>();

            validation.OtherProperty = otherProperty;
            validation.ErrorMessage = errorMessage;
            validation.ErrorMessageResourceType = errorMessageResourceType;
            validation.ErrorMessageResourceName = errorMessageResourceName;

            return self;
        }
    }
}