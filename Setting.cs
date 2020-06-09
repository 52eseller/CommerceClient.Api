﻿using System.Collections.Generic;

namespace Commerce.Api.Model
{
    public class Setting
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string Module { get; set; }

        /// <summary>
        /// Indicates if the configuration value is a module implementation.
        /// Module implementations facilitates different behaviour for modules, and may radically change
        /// behaviour, data model, data store etc for the module.
        /// You may use this information to customize behaviour of your app.
        /// </summary>
        public bool? IsModuleImplementation { get; set; }

        /// <summary>
        /// Indicates what module implementation this parameter works for.
        /// </summary>
        public string Implementation { get; set; }

#pragma warning disable CA1819 // Properties should not return arrays
        public List<string> Aliases { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
    }
}