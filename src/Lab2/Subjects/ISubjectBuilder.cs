using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public interface ISubjectBuilder
{
        public void SetId(Guid id);

        public void SetAuthor(User author);

        public void SetName(string name);

        public void SetPoints(float points);

        public Subject Build();
}