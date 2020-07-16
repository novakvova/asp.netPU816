using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bicycle.Web.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreateDate { get; set; }
        DateTime ModifyDate { get; set; }
        DateTime DeleteDate { get; set; }
    }

    public abstract class BaseEntity<T> : IEntity<T>
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}