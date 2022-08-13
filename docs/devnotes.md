# Development setup notes

This documents the steps to getting a Linux developer laptop set up on an old Windows laptop.
The goal was to get it ready to do learn modern development techniques using: git, Github, C#, .Net, docker, Azure, etc.

Laptop hardware configuration is as follows:
- Intel(R) Core(TM) i3-2370M CPU @ 2.40GHz
- 8 GB RAM
- 500 GB hard drive

## Laptop setup

Decided to convert Windows laptop to Xubuntu (lightweight xfce based Ubuntu flavor): https://xubuntu.org/ 


### Basic OS install

**Setup**

- On Windows laptop, download x64 based Xubuntu 22.04 install ISO file 
- Used https://www.pendrivelinux.com/yumi-multiboot-usb-creator/ to create bootable USB drive (minimum 4 GB USB drive required)
- Copied any required documents and files off Windows laptop to backup drive

**Install**

- Insert bootable USB, reboot and boot from USB (my laptop needed F12 key to show boot menu)
- Follow installation instructions, I chose to wipe out old partitions and Windows OS completely 

### Basic development setup

**On local machine**

- Install git (do: sudo apt-get install git)
- Install dotnet (see: https://docs.microsoft.com/en-us/dotnet/core/install/linux)
- Install VS Code (see: https://code.visualstudio.com/docs/setup/linux)
- Do setup within VS Code to enable C# development and debugging

**Github**

It is very convenient for an individual developer to publish and back up their git repository to Github

- Create account online
- Create initial repository
- In local repository, set up Github repo as remote
- Do normal development operations using git, and push to remote as needed
