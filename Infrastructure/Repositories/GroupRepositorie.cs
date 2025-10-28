using Application.DTOs.Secondary;
using Application.Interfaces.ForRepositories;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class GroupRepositorie : IGroupRepositorie
    {
        private readonly AppDbContext _appDbContext;

        private readonly ILogger<GroupRepositorie> _logger;

        public GroupRepositorie(AppDbContext appDbContext, ILogger<GroupRepositorie> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task AddStudentInGroupAsync(Student student)
        {
            int courseId = student.CourseId;

            StudentEnrollment studentEnrollment = _appDbContext.StudentEnrollments.ToList().Find(x => x.StudentId == student.Id);

            List<Group>  courseGroups = _appDbContext.Groups.Where(x => x.CourseId == courseId).ToList();

            List<Student> courseStudents = _appDbContext.Students.Where(x => x.CourseId == courseId).ToList();

            for (int i = 0; courseGroups.Count > 0; i++)
            {
                for (int j = 0; j < courseStudents.Count; j++)
                {
                    if (studentEnrollment.PreferredPeerIds.Contains(courseStudents[j].Id) && !studentEnrollment.BlacklistedPeerIds.Contains(courseStudents[j].Id))
                    {
                        student.GroupId = i;

                        return;
                    }
                }
            }

            for (int i = 0; courseGroups.Count > 0; i++)
            {
                for (int j = 0; j < courseStudents.Count; j++)
                {
                    if (!studentEnrollment.BlacklistedPeerIds.Contains(courseStudents[j].Id))
                    {
                        student.GroupId = i;

                        return;
                    }
                }
            }

            await AddGroupsAsync(courseId);
        }

        private async Task AddGroupsAsync(int courseId)
        {
            List<Group> groups = await _appDbContext.Groups.ToListAsync();
            List<Course> courses = await _appDbContext.Courses.ToListAsync();

            if (courses.Find(x => x.Id == courseId).MaxGroupSize > groups.Count)
            {
                await _appDbContext.Groups.AddAsync(new Group { CourseId = courseId });
            }

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<ParticularGroup>> GetGroupsByCourseIdAsync(int courseId)
        {
            List<ParticularGroup> particularGroups = new List<ParticularGroup>();

            List<Group> groups = _appDbContext.Groups.Where(x => x.CourseId == courseId).ToList();

            for (int i = 0; i < groups.Count; i++)
            {
                particularGroups[i].Id = groups[i].Id;

                List<int> memberIds = new List<int>();
                
                for (int j = 0; j < _appDbContext.Students.Count(); j++)
                {
                    if (_appDbContext.Students.ToList()[0].GroupId == groups[i].Id)
                    {
                        particularGroups[i].MembersIds.Add(_appDbContext.Students.ToList()[0].Id);
                    }
                }
            }

            return particularGroups;
        }
    }
}                                                          