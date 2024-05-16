using Microsoft.EntityFrameworkCore;
using Moq;

namespace Project.Tests.HelpTestScripts; 

public static class DbSetMock
{
    public static DbSet<T> Create<T>(IQueryable<T> data) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<T>(data.Provider));
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        mockSet.As<IAsyncEnumerable<T>>().Setup(m => m.GetAsyncEnumerator(It.IsAny<System.Threading.CancellationToken>())).Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));
        mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>()))
            .ReturnsAsync((object[] ids) => data.FirstOrDefault(d => ids.Contains(d.GetType().GetProperty("Id").GetValue(d))));

        return mockSet.Object;
    }

}