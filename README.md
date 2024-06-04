# AutoCloseDoors
### Server Only Mod
Server only mod for Auto Close Doors.

## Installation
Copy & paste the `AutoCloseDoors.dll` to `\Server\BepInEx\plugins\` folder.

## Removal
If your server is on windows, or can be shutdown properly.\
All you need to do to remove the mod is shutdown your server and delete the dll.

If your server is on linux, or can't be shutdown properly\
Make sure to disable the plugin by using the command ".acd disable" before removing the dll.\
Shutdown your server and remove the dll.

## Config
<details>
<summary>Config</summary>

- `Enable Auto Close Doors` [default `true`]\
Switch on/off auto close for doors.
- `Auto Close Timer` [default `2.0`]\
How many second(s) to wait before door is automatically closed.
- `Always Auto Close Doors` [default `false`]\
When this is set to false, doors will not automatically close if castle is decaying, under attack, or being sieged.

</details>

## Commands

<details>
<summary>Disable mod</summary>

`.acd disable`\

Revert all doors in the game world to not close automatically (admin only).

</details>

<details>
<summary>Enable mod</summary>

`.acd enable`\

Enable the mod to close the doors after X seconds (admin only).

</details>

## More Information
<details>
<summary>Changelog</summary>

`2.0.0`
- Initial Release for 1.0

</details>

### General

This mod was forked from AutoCloseDoors mod by [@Kaltharos](https://github.com/Kaltharos/AutoCloseDoors/tree/master).

@Deca, VampireCommandFramework and Bloodstone.

</details>