using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicVote.Entities
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AuditableAttribute:Attribute
    {
    }
}
