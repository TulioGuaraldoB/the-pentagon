using System.ComponentModel;

namespace Core.Domain.Entities
{
    public enum Corp
    {
        [Description("Navy SEALS")]
        Navy = 1,
        [Description("The Marines")]
        Marine = 2,
    }
}