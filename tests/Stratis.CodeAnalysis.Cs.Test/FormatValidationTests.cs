using System.Collections.Immutable;
using System.Threading.Tasks;
using System.IO;

using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VerifyCS = Stratis.CodeAnalysis.Cs.Test.CSharpCodeFixVerifier<
    Stratis.CodeAnalysis.Cs.SmartContractAnalyzer,
    Stratis.CodeAnalysis.Cs.StratisCodeAnalysisCsCodeFixProvider>;

namespace Stratis.CodeAnalysis.Cs.Test
{
    [TestClass]
    public class FormatValidationTests
    {
        [TestMethod]
        public async Task NamespaceDeclNotAllowedTest()
        {
            var code = 
@"namespace ns1
{
    using Stratis.SmartContracts;
    public class Player : SmartContract
    {
        public Player(ISmartContractState state, Address player, Address opponent, string gameName)
            : base(state)
        {
           
        }
    }
}";
            await VerifyCS.VerifyAnalyzerAsync(code, VerifyCS.Diagnostic("SC0001").WithSpan(1, 11, 1, 14).WithArguments("ns1"));
        }
    }
}
