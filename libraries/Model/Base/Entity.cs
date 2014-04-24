using Model.Base;

namespace Model
{
    public class Entity : AuditableEntity, IEntity, IAuditable
    {
        public int Id { get; set; }
    }
}
