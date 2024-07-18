{ pkgs ? import (builtins.fetchTarball "https://github.com/NixOS/nixpkgs/archive/24.05.tar.gz") {}
}: pkgs.mkShell {
	packages = builtins.attrValues { inherit (pkgs) dotnet-sdk_8 mono; };
/*
	shellHook = ''
		export DOTNET_ROOT="${pkgs.dotnet-runtime_8}"
	'';
*/
}
