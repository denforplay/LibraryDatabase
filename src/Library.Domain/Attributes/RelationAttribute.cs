using Library.Domain.Enums;
using Library.Domain.Interfaces;

namespace Library.Domain.Attributes
{
    public class RelationAttribute : Attribute
    {
        public RelationType RelationType { get; private set; }
        public Type RepositoryEntityType { get; private set; }
        public Type RepositoryRelationEntityType { get; private set; }
        public string ForeignKeyName { get; private set; }

        public RelationAttribute(RelationType relationType, Type repositoryEntityType, Type repositoryRelationEntityType, string foreignKeyName)
        {
            RelationType = relationType;
            RepositoryEntityType = repositoryEntityType;
            RepositoryRelationEntityType = repositoryRelationEntityType;
            ForeignKeyName = foreignKeyName;
        }
    }
}
