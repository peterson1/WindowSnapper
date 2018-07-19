using FluentAssertions;
using WindowSnapper.Core;
using Xunit;

namespace WindowSnapper.Tests.MonoDisplayTests
{
    [Trait("Mono Display", "Vertical Split")]
    public class VerticalSplitFacts
    {
        [Fact(DisplayName = "800x600 / 1")]
        public void TestMethod00001()
        {
            var sut = new VerticalScreenSplitter
                (Display.Define(800, 600, 0, 0, 1, 0));

            sut.PostionAt(1).Left  .Should().Be(0);
            sut.PostionAt(1).Top   .Should().Be(0);
            sut.PostionAt(1).Width .Should().Be(800);
            sut.PostionAt(1).Height.Should().Be(600);

            sut.PostionAt(2).Should().BeNull();
        }


        [Fact(DisplayName = "800x600 / 3")]
        public void TestMethod00002()
        {
            var sut = new VerticalScreenSplitter
                (Display.Define(800, 600, 0, 0, 3, 0));

            sut.PostionAt(1).Left  .Should().Be(0);
            sut.PostionAt(1).Top   .Should().Be(0);
            sut.PostionAt(1).Width .Should().Be(800 / 3);
            sut.PostionAt(1).Height.Should().Be(600);

            sut.PostionAt(2).Left  .Should().Be(800 / 3);
            sut.PostionAt(2).Top   .Should().Be(0);
            sut.PostionAt(2).Width .Should().Be(800 / 3);
            sut.PostionAt(2).Height.Should().Be(600);

            sut.PostionAt(3).Left  .Should().Be((800 / 3) * 2);
            sut.PostionAt(3).Top   .Should().Be(0);
            sut.PostionAt(3).Width .Should().Be(800 / 3);
            sut.PostionAt(3).Height.Should().Be(600);
        }
    }
}
