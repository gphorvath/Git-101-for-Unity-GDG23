# GameDevGuildConference2023

## Git Setup

### Install Git v2.34+

https://git-scm.com/

### Create SSH Key

``` sh
ssh-keygen -t ed25519 -C "example@email.com"
```

### Configure Git

``` sh
git config --global user.name "First Last"
git config --global user.email "example@email.com"
git config --global gpg.format ssh
git config --global user.signingkey ~/.ssh/id_ed25519.pub
git config --global commit.gpgsign true
```

### Add SSH Key to GitHub

``` sh
cat ~/.ssh/id_ed25519.pub | clip
```

Navigate to https://github.com/settings/keys

1. Add for Authentication
2. Add for Signing

### Cache Authentication Credentials

To avoid having to type your key repeatedly, add this to your `~/.profile` or `~/.bashrc`:

``` sh
env=~/.ssh/agent.env

agent_load_env () { test -f "$env" && . "$env" >| /dev/null ; }

agent_start () {
    (umask 077; ssh-agent >| "$env")
    . "$env" >| /dev/null ; }

agent_load_env

# agent_run_state: 0=agent running w/ key; 1=agent w/o key; 2=agent not running
agent_run_state=$(ssh-add -l >| /dev/null 2>&1; echo $?)

if [ ! "$SSH_AUTH_SOCK" ] || [ $agent_run_state = 2 ]; then
    agent_start
    ssh-add
elif [ "$SSH_AUTH_SOCK" ] && [ $agent_run_state = 1 ]; then
    ssh-add
fi

unset env
```

If you ever update your key just run this:

``` sh
ssh-add ~/.ssh/id_ed25519
```

## GameCI

### Environment Variables

The following variables are required to configure build automation with GameCI:

> UNITY_LICENSE  
> UNITY_EMAIL  
> UNITY_PASSWORD  

In order to obtain `UNITY_LICENSE` please follow the directions at <https://game.ci/docs/github/activation>.

### Notes

In GitHub project settings, grant your runner Read/Write permissions.

Add these lines to the `.gitignore`:

```yaml
# GameCI
/[Aa]rtifacts/
/[Cc]odeCoverage/
```

In Unity, disable compression under `Player Settings -> WebGL -> Publishing Settings`.  This substantially improves build times (`40mins -> 5mins`).