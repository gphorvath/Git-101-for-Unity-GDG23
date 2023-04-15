# GameDevGuildConference2023

## GameCI

### Environment Variables

The following variables are required to configure build automation with GameCI:

> UNITY_LICENSE  
> UNITY_EMAIL  
> UNITY_PASSWORD  

In order to obtain `UNITY_LICENSE` please follow the directions at <https://game.ci/docs/github/activation>.

### Notes

A few things I changed to fix some bugs.

Added these lines to the `.gitignore`:

```yaml
# GameCI
/[Aa]rtifacts/
/[Cc]odeCoverage/
```

Disabled compression under `Player Settings -> WebGL -> Publishing Settings`.  This substantially improved build times (`40mins -> 5mins`).