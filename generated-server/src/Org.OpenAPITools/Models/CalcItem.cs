/*
 * Simple Calculator API
 *
 * This is a simple API
 *
 * The version of the OpenAPI document: 1.0.0
 * Contact: tsahikamar@gmail.com
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Org.OpenAPITools.Converters;

namespace Org.OpenAPITools.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class CalcItem : IEquatable<CalcItem>
    {
        /// <summary>
        /// Gets or Sets Num1
        /// </summary>
        /* <example>200</example> */
        [Required]
        [DataMember(Name="num1", EmitDefaultValue=true)]
        public float Num1 { get; set; }

        /// <summary>
        /// Gets or Sets Num2
        /// </summary>
        /* <example>500</example> */
        [Required]
        [DataMember(Name="num2", EmitDefaultValue=true)]
        public float Num2 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CalcItem {\n");
            sb.Append("  Num1: ").Append(Num1).Append("\n");
            sb.Append("  Num2: ").Append(Num2).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((CalcItem)obj);
        }

        /// <summary>
        /// Returns true if CalcItem instances are equal
        /// </summary>
        /// <param name="other">Instance of CalcItem to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CalcItem other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Num1 == other.Num1 ||
                    
                    Num1.Equals(other.Num1)
                ) && 
                (
                    Num2 == other.Num2 ||
                    
                    Num2.Equals(other.Num2)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    
                    hashCode = hashCode * 59 + Num1.GetHashCode();
                    
                    hashCode = hashCode * 59 + Num2.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(CalcItem left, CalcItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CalcItem left, CalcItem right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
