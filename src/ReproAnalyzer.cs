using System.Collections.Immutable;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class ReproAnalyzer: DiagnosticAnalyzer {
	private static readonly DiagnosticDescriptor DiagRepro = new(
		id: "DUMMY001",
		title: "example",
		messageFormat: "example",
		category: "Usage",
		defaultSeverity: DiagnosticSeverity.Warning,
		isEnabledByDefault: true
	);

	public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(DiagRepro);

	public override void Initialize(AnalysisContext context) {
		context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
		context.EnableConcurrentExecution();
		context.RegisterOperationAction(
			oac => oac.ReportDiagnostic(Diagnostic.Create(DiagRepro, oac.Operation.Syntax.GetLocation())),
			OperationKind.MethodBody
		);
	}
}
