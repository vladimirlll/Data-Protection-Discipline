using DI.Lab1.Code.Exceptions;
using DI.Lab1.Code.Models;
using FluentAssertions;

namespace DI.Lab1.Tests
{
    public class ObjectPlanTests
    {
        [Fact]
        public void ObjectPlanBuilder_SetAnyCoordinate_BeforeSetFence_GeneratesException()
        {
            Action yWindow = () =>
            {
                ObjectPlan.Builder builder = new();
                builder.SetYWindow(10);
            };
            yWindow.Should().Throw<FenceCoordinateNotSetException>();

            Action xFWindow = () =>
            {
                ObjectPlan.Builder builder = new();
                builder.SetXFirstWindow(10);
            };
            xFWindow.Should().Throw<FenceCoordinateNotSetException>();

            Action xSWindow = () =>
            {
                ObjectPlan.Builder builder = new();
                builder.SetXSecondWindow(10);
            };
            xSWindow.Should().Throw<FenceCoordinateNotSetException>();

            Action xInfSys = () =>
            {
                ObjectPlan.Builder builder = new();
                builder.SetXInfSys(10);
            };
            xInfSys.Should().Throw<FenceCoordinateNotSetException>();

            Action yInfSys = () =>
            {
                ObjectPlan.Builder builder = new();
                builder.SetYInfSys(10);
            };
            yInfSys.Should().Throw<FenceCoordinateNotSetException>();

        }

        [Fact]
        public void ObjectPlanBuilder_SetAnyCoordinate_MoreThanFenceCoordinate_GeneratesException()
        {
            Action yWindow = () =>
            {
                ObjectPlan.Builder builder = new();
                builder.SetXFence(100);
                builder.SetYFence(100);
                builder.SetYWindow(101);
            };
            yWindow.Should().Throw<IncorrectCoordinateException>();

            Action xFWindow = () =>
            {
                ObjectPlan.Builder builder = new();
                builder.SetXFence(100);
                builder.SetYFence(100);
                builder.SetXFirstWindow(101);
            };
            xFWindow.Should().Throw<IncorrectCoordinateException>();

            Action xSWindow = () =>
            {
                ObjectPlan.Builder builder = new();
                builder.SetXFence(100);
                builder.SetYFence(100);
                builder.SetXSecondWindow(101);
            };
            xSWindow.Should().Throw<IncorrectCoordinateException>();

            Action xInfSys = () =>
            {
                ObjectPlan.Builder builder = new();
                builder.SetXFence(100);
                builder.SetYFence(100);
                builder.SetXInfSys(101);
            };
            xInfSys.Should().Throw<IncorrectCoordinateException>();

            Action yInfSys = () =>
            {
                ObjectPlan.Builder builder = new();
                builder.SetXFence(100);
                builder.SetYFence(100);
                builder.SetYInfSys(101);
            };
            yInfSys.Should().Throw<IncorrectCoordinateException>();
        }
    }
}
