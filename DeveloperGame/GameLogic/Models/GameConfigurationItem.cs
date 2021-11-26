using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic.Models
{
    public class GameConfigurationItem
    {
        /// <summary>
        /// Prompt text which describes the setting and acceptable vales.
        /// </summary>
        public string Prompt { get; set; }

        /// <summary>
        /// A method that takes a string input which is used to set the associated configuration value.
        /// </summary>
        public Action<string> SetConfiguration { get; set; }

        /// <summary>
        /// Returns <see cref="true"/> if the associated configuration value has been set.
        /// </summary>
        public Func<bool> IsSet { get; set; }
    }
}
