# Chardown

Chardown is a command-line tool for converting conventionally-formatted Markdown character sheets to form-filled PDF character sheets.

## Usage

`chardown.exe {path-to-existing-character-sheet.markdown} {path-to-new-character-sheet.pdf}`

## Markdown Character Sheet Format

Chardown expects Markdown character sheets to be formatted as follows:

```
# {character-name}

**STR** {str-value} ({str-modifier})
**DEX** {dex-value} ({dex-modifier})
**CON** {con-value} ({con-modifier})
**INT** {int-value} ({int-modifier})
**WIS** {wis-value} ({wis-modifier})
**CHA** {cha-value} ({cha-modifier})
```