using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Verify = Microsoft.CodeAnalysis.CSharp.Testing.CSharpAnalyzerVerifier<ReproAnalyzer, Microsoft.CodeAnalysis.Testing.DefaultVerifier>;

[TestClass]
public sealed class ReproAnalyzerTests {
	[TestMethod]
	public Task RunTest()
		=> Verify.VerifyAnalyzerAsync("""
			public static class AClass {
				{|DUMMY001:public static void AMethod() { return; }|}
			}
		""");
}
