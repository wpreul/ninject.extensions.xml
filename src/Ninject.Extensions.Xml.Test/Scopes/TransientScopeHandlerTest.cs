//-------------------------------------------------------------------------------
// <copyright file="TransientScopeHandlerTest.cs" company="Ninject Project Contributors">
//   Copyright (c) 2009-2011 Ninject Project Contributors
//   Authors: Remo Gloor (remo.gloor@gmail.com)
//           
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   you may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

#if !NO_MOQ
namespace Ninject.Extensions.Xml.Scopes
{
    using FluentAssertions;
    using Moq;
    using Ninject.Syntax;
    using Xunit;

    public class TransientScopeHandlerTest
    {
        private readonly TransientScopeHandler testee;

        public TransientScopeHandlerTest()
        {
            this.testee = new TransientScopeHandler();
        }

        [Fact]
        public void Name()
        {
            TransientScopeHandler.Name.Should().Be("transient");
        }

        [Fact]
        public void ScopeName()
        {
            this.testee.ScopeName.Should().Be(TransientScopeHandler.Name);
        }

#if !NO_GENERIC_MOQ
        [Fact]
        public void SetScopeSetsTheSingletonScopeOnTheSyntax()
        {
            var syntaxMock = new Mock<IBindingInSyntax<object>>();

            this.testee.SetScope(syntaxMock.Object);

            syntaxMock.Verify(s => s.InTransientScope());
        }
#endif
    }
}
#endif