# AutoCloseDoors
### Server Only Mod
Server only mod for Auto Close Doors.

## Installation
Copy & paste the `AutoCloseDoors.dll` to `\Server\BepInEx\plugins\` folder.

## Removal
If your server is on windows or can be shutdown properly, all you need to do is, remove the mod dll, shutdown your server and delete the dll.

If your server is on linux or can't be shutdown properly, make sure to disable the plugin by using the command ".acd disable" before removing the dll.
Shutdown your server and remove the dll.

## Config
<details>
<summary>Config</summary>

- `Enable Auto Close Doors` [default `true`]\
Switch on/off auto close for doors.
- `Auto Close Timer` [default `2.0`]\
How many second(s) to wait before door is automatically closed.

</details>

## Commands

<details>
<summary>Disable mod</summary>

`.acd disable`

Revert all doors in the game world to not close automatically (admin only).

</details>

<details>
<summary>Enable mod</summary>

`.acd enable`

Enable the mod to close the doors after X seconds (admin only).

</details>

<details>
<summary>Set time</summary>

`.acd time <seconds>`

Changes the auto close timer on the fly (admin only).

</details>

### Credits

This mod was forked from AutoCloseDoors mod by [@Kaltharos](https://github.com/Kaltharos/AutoCloseDoors/tree/master).

[Deca](https://github.com/deca) VampireCommandFramework.

[odjit](https://github.com/odjit) Ideas and some code snippets.

</details>