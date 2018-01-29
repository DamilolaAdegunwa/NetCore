﻿using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NetCoreCQRS;
using NetCoreTests.Commands;
using NetCoreTests.Queries;
using NUnit.Framework;

namespace NetCoreTests
{
    [TestFixture]
    public class ExecutorTests: BaseTest
    {
        [Test]
        public void Executor_AddAndGetTestEntity_ReturnExistedTestEntities_Success()
        {
            var executor = ServiceProvider.GetService<IExecutor>();

            executor.GetCommand<CreateTestEntityCommand>().Process(command => command.Execute());
            var testEntities = executor.GetQuery<GetTestEntityQuery>().Process(query => query.Execute());

            executor.Should().NotBeNull();
            testEntities.Should().NotBeNull();
            testEntities.Count.Should().BeGreaterThan(0);
        }
    }
}
