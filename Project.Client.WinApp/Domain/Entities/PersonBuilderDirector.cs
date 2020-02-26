namespace Project.Client.WinApp.Domain.Entities
{
    public class PersonBuilderDirector : PersonJobBuilder<PersonBuilderDirector>
    {
        public static PersonBuilderDirector Create() => new PersonBuilderDirector();
    }
}