using FluentAssertions;
using WindowSnapper.Core;
using Xunit;

namespace WindowSnapper.Tests.DualDisplayTests
{
    [Trait("Dual Display", "Vertical Split")]
    public class VerticalSplitFacts
    {
        [Fact(DisplayName = "vertical, by 1, by 3")]
        public void TestMethod00001()
        {
            var sut = new VerticalScreenSplitter(
                Display.Define(800, 600, 0, 0, 1, 0),
                Display.Define(300, 400, 0, 600, 3, 0));

            sut.PostionAt(1).Left  .Should().Be(0);
            sut.PostionAt(1).Top   .Should().Be(0);
            sut.PostionAt(1).Width .Should().Be(800);
            sut.PostionAt(1).Height.Should().Be(600);

            sut.PostionAt(3).Should().BeNull();

            sut.PostionAt(1, 1).Left  .Should().Be(0);
            sut.PostionAt(1, 1).Top   .Should().Be(600);
            sut.PostionAt(1, 1).Width .Should().Be(100);
            sut.PostionAt(1, 1).Height.Should().Be(400);

            sut.PostionAt(2, 1).Left  .Should().Be(100);
            sut.PostionAt(2, 1).Top   .Should().Be(600);
            sut.PostionAt(2, 1).Width .Should().Be(100);
            sut.PostionAt(2, 1).Height.Should().Be(400);

            sut.PostionAt(3, 1).Left  .Should().Be(200);
            sut.PostionAt(3, 1).Top   .Should().Be(600);
            sut.PostionAt(3, 1).Width .Should().Be(100);
            sut.PostionAt(3, 1).Height.Should().Be(400);

            sut.PostionAt(4, 1).Should().BeNull();
            sut.PostionAt(1, 2).Should().BeNull();
        }


        [Fact(DisplayName = "horizontal by 5, by 3")]
        public void TestMethod00002()
        {
            var sut = new VerticalScreenSplitter(
                Display.Define(500, 700, 0, 0, 5, 0),
                Display.Define(600, 400, 500, 0, 3, 0));

            sut.PostionAt(1).Left  .Should().Be(0);
            sut.PostionAt(1).Top   .Should().Be(0);
            sut.PostionAt(1).Width .Should().Be(100);
            sut.PostionAt(1).Height.Should().Be(700);

            sut.PostionAt(2).Left  .Should().Be(100);
            sut.PostionAt(2).Top   .Should().Be(0);
            sut.PostionAt(2).Width .Should().Be(100);
            sut.PostionAt(2).Height.Should().Be(700);

            sut.PostionAt(3).Left  .Should().Be(200);
            sut.PostionAt(3).Top   .Should().Be(0);
            sut.PostionAt(3).Width .Should().Be(100);
            sut.PostionAt(3).Height.Should().Be(700);

            sut.PostionAt(4).Left  .Should().Be(300);
            sut.PostionAt(4).Top   .Should().Be(0);
            sut.PostionAt(4).Width .Should().Be(100);
            sut.PostionAt(4).Height.Should().Be(700);

            sut.PostionAt(5).Left  .Should().Be(400);
            sut.PostionAt(5).Top   .Should().Be(0);
            sut.PostionAt(5).Width .Should().Be(100);
            sut.PostionAt(5).Height.Should().Be(700);

            sut.PostionAt(1, 1).Left  .Should().Be(500);
            sut.PostionAt(1, 1).Top   .Should().Be(0);
            sut.PostionAt(1, 1).Width .Should().Be(200);
            sut.PostionAt(1, 1).Height.Should().Be(400);

            sut.PostionAt(2, 1).Left  .Should().Be(700);
            sut.PostionAt(2, 1).Top   .Should().Be(0);
            sut.PostionAt(2, 1).Width .Should().Be(200);
            sut.PostionAt(2, 1).Height.Should().Be(400);

            sut.PostionAt(3, 1).Left  .Should().Be(900);
            sut.PostionAt(3, 1).Top   .Should().Be(0);
            sut.PostionAt(3, 1).Width .Should().Be(200);
            sut.PostionAt(3, 1).Height.Should().Be(400);
        }
    }
}
