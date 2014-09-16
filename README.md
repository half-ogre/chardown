# Chardown

Chardown is a command-line tool for converting form-filled D&D 5e PDF character sheets to conventionally-composed Markdown (and back again from Markdown to PDF).

## Usage

To convert a form-filled character sheet to Markdown:

`chardown.exe {path-to-existing-character-sheet.pdf} {path-to-new-character-sheet.markdown}`

To convert a Markdown character sheet (that meets the expected composition) to a form-filled PDF:

`chardown.exe {path-to-existing-character-sheet.markdown} {path-to-new-character-sheet.pdf}`

## Markdown Character Sheet Expected Composition

Chardown will create Markdown character sheets according the following composition, and when converting an existing Markdown file to PDF expect the same composition.

```
# {character-name}

**STR** {str-value} ({str-modifier})
**DEX** {dex-value} ({dex-modifier})
**CON** {con-value} ({con-modifier})
**INT** {int-value} ({int-modifier})
**WIS** {wis-value} ({wis-modifier})
**CHA** {cha-value} ({cha-modifier})
```