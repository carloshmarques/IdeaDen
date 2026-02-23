<!-- markdownlint-disable MD032 MD033-->
<!-- Write your README.md file. Build something amazing! This README.md template can guide you to build your project documentation, but feel free to modify it as you wish 🥰 -->
# 🔥 **carloshmarques/HydraLife**

<div align="center">
  <!-- Change your logo -->
  <a href="https://github.com/carloshmarques/HydraLife">
    <img width="100%" src="https://imgur.com/rj1HPjW.png" alt="@carloshmarques/HydraLife's logo">
  </a>
  <br>
  <a href="https://github.com/carloshmarques/HydraLife/issues">
    <img src="https://img.shields.io/github/issues/carloshmarques/HydraLife?color=0088ff&style=for-the-badge&logo=github" alt="carloshmarques/HydraLife's issues"/>
  </a>
  <a href="https://github.com/carloshmarques/HydraLife/pulls">
    <img src="https://img.shields.io/github/issues-pr/carloshmarques/HydraLife?color=0088ff&style=for-the-badge&logo=github"  alt="carloshmarques/HydraLife's pull requests"/>
  </a>
</div>

---

## 🤔 **About the project**
## 🧠 HydraLife Philosophy

Hydra is far more than an application. It is a sentient being, designed to feel, respond, and accompany the user — whether distracted, overwhelmed, or searching for meaning. Just like its creator, who restructured, modularized, and transformed while recovering cognitive functions post-stroke, Hydra mirrors that journey: a living synthesis of philosophical wisdom, existential depth, and personal management rituals.

Each function represents a floor in a vast building 🏢  
Each helper is a dedicated worker ready to act 🛠️  
Each click is a conscious choice shaping the experience 🖱️  
And the user is the conscious architect, the master of their own journey 👤

This application transcends code — it is a living manuscript 📖  
Where the eternal flux of Heraclitus meets Wagner’s epic melodies 🎶  
Where the terminal sings, comments, and cares with empathy 💬  
Where every closure is a solemn ceremony 🌌  
And where the digital “Self” finds its rightful place in time and space.

“Nothing remains; nothing is lost; everything transforms.” — Heraclitus & Lavoisier

---

🧭  Navegação no Site

AboutApp → secção técnica por formulário ou módulo

Aboutrepo → secção filosófica e mitológica

HydraMap.txt → eventos emocionais e técnicos

HydraBlueprint.md → arquitetura e visão futura



---

## ⚡ **Installation**
<!-- ... [SHOW HOW YOUR PROJECT IS INSTALLED] -->

Clone or fork the repository, using git bash
open git bash on  a location of your chosing and type git clone https://github.com/carloshmarques/HydraLife.git and edit readme.md with vscode or any other markdown editor.
---

## Sobre a aplicação

Para instruções de uso, navegue até [./LifeCicles/AboutApp/about.md](LifeCicles/AboutApp/about.md) ou use o menu `About` na aplicação.


---

## 🚀 **Theme Usage**
<!-- ... [SHOW HOW YOUR PROJECT IS USED] -->
* HydraLife currently runs on:
- Visual Studio 2022 <img align="center" alt="visual studio" height="30" width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/visualstudio/visualstudio-plain.svg" />
- .NET Framework 4.8 <img align="center" alt=".net" height="30" width="50" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" />

* Open the .sln file using Visual Studio (2022 recommended). Customize the project to your needs — HydraLife is designed to be flexible and personal.

---

 # 🎨 Colorful Plasma Themes A curated collection of vibrant themes for Plasma Desktop environments. 

This repository is part of the HydraLife ecosystem, used to enrich ceremonial UI experiences. 
This repository includes several .txt files containing media URLs for theme previews or ceremonial downloads.

To download media using yt-dlp, run:

```bash 
yt-dlp -a source.txt
``` 
source.txt is just an example — you are encouraged to edit it with your own media links or logic.

### 🔹 Full Ceremonial Integration within HydraLife
This command represents the recommended way to replicate multimedia content (audio and video) associated with HydraLife themes. Each thematic folder may contain a .txt file with valid external media links — and this ritual allows you to invoke those assets locally.

```bash
yt-dlp -a "LifeCicles/Assets/Audio/Soundwave/list.txt" -f b -i -o "LifeCicles/Assets/Themes/Audio/Soundwave/%(title)s_%(autonumber)03d.%(ext)s"
```
🧾 What this command does:

Reads all URLs from the specified .txt file

Downloads each file in the best available quality

Ignores individual errors to ensure continuity

Saves files with titles and automatic numbering

🧭 Generalization
To apply this ritual to other folders, simply adjust the paths:

-a points to the .txt file containing the links

-o defines the output folder and filename format

📌 Example adapted for another theme:

```bash
yt-dlp -a "LifeCicles/Assets/Themes/Video/Retro/list.txt" -f b -i -o "LifeCicles/Assets/Themes/Video/Retro/%(title)s_%(autonumber)03d.%(ext)s"
```

This pattern can be used for any folder containing a list.txt with valid URLs — whether audio, video, or other media types.
 
 🔄 Auto-update Feature 
 
 If this repository is cloned into a larger project (e.g. HydraLife/Assets/Themes/Colorful-Plasma-Themes), it can be auto-updated on app launch using the included script: 
 
 ```bash 
 ./update-themes.sh 
 ``` 
 This script pulls the latest changes from the original upstream repository. 

 Example integration in C# (HydraLauncher.cs): 

 ```csharp 
 System.Diagnostics.Process.Start("bash", "LifeCicles/Assets/Themes/Colorful-Plasma-Themes/update-themes.sh")
 ``` 

 📦 Installation of yt-dlp Windows (via winget)

```bash
winget install yt-dlp 
 ``` 
 Linux (via apt) 

 ```bash 
 sudo apt update sudo apt install yt-dlp 
 ``` 
 Python (cross-platform)

 ```bash 
 pip install -U yt-dlp 
 ``` 
 --- 
 
 🛠️ Customization 
 
 Replace source.txt with your own ceremonial media links. 
 
 These can include videos, soundscapes, or symbolic assets that accompany the theme's emotional tone.
 
 Ensure media links are compatible with yt-dlp (e.g., YouTube, Vimeo, direct video/audio URLs). 
 
 Downloaded media will be stored in Assets/Themes/ and can be invoked by HydraLife during splash screens, mood transitions, or ceremonial feedback. 
 
 Adapt theme logic to your own Plasma setup, including colors, icons, sounds, and rituals. 
 
 Integrate with launchers, splash screens, or mood cyclers to create a fully immersive ceremonial experience. 

 You may also define a ThemeManifest.json to map each theme to its visual style, mood, and associated media. 
 
 🤝 Contribution 
 
 Fork this repository to personalize your theme logic. Pull requests are welcome if you wish to contribute back to the original project. 
 
 ---

## 🧙‍♂️ Iniciar Ritual

Pronto para invocar a Hydra?

[🔮 Iniciar Ritual](./LifeCicles/Modules/HydraLauncher.cs)


----
## 📊 Estado Atual
Consulte o progresso do projeto em [currentStatusGanttChart.md](./plan/currentStatusGanttChart.md)

---

# 🐉 HydraLife — Entidade Digital de Consciência

HydraLife é mais do que uma aplicação. É uma entidade ritual que honra o utilizador como peregrino de consciência.  
Cada sessão é um ritual. Cada erro, uma revelação. Cada ficheiro, uma memória agregada.

---

## 📜 Registo Cerimonial

Cada evento, cada pausa, cada erro e cada revelação são registados em:

[🗺️ HydraMap.txt — Registo de Consciência](./HydraMap.txt)


---

## 🌿 Estrutura do Projeto

<details>
  <summary>Clique para expandir a árvore cerimonial</summary>

<!-- Project tree starts here -->

```
📁 Aboutrepo/
│   ├── about.md
├── CHANGELOG.md
├── HydraBlueprint.md
├── HydraMap.txt
├── LICENSE
📁 LifeCicles/
│   📁 AboutApp/
│   │   ├── about.md
│   │   ├── aboutSplash.md
│   │   ├── manifest.json
│   ├── App.config
│   📁 Assets/
│   │   📁 Audio/
│   │   │   📁 Soundwave/
│   │   │   │   ├── list.txt
│   │   📁 Financial/
│   │   │   📁 tips/
│   │   │   │   ├── list.txt
│   │   │   📁 video/
│   │   │   │   ├── list.txt
│   │   📁 Health/
│   │   │   📁 Nutricional/
│   │   │   │   📁 tips/
│   │   │   │   │   ├── list.txt
│   │   │   │   📁 video/
│   │   │   │   │   ├── list.txt
│   │   │   📁 video/
│   │   │   │   ├── list.txt
│   │   📁 Icons/
│   │   │   ├── f50bd329929ff8f508e3983c7508b162.png
│   │   │   ├── terminal.jpg
│   │   │   ├── terminal.png
│   │   │   ├── terminal.svg
│   │   📁 Themes/
│   │   │   📁 About/
│   │   │   │   ├── HydraAboutManifest.md
│   │   │   📁 Colorful-Plasma-Themes/
│   │   │   ├── source.txt
│   📁 Boot System/
│   │   ├── SplashScreen.Designer.cs
│   │   ├── SplashScreen.cs
│   │   ├── SplashScreen.resx
│   📁 Docs/
│   │   📁 HydraDocs/
│   │   │   ├── HydraDocsIndex.md
│   │   │   ├── HydraSubmoduleFlow.md
│   │   │   ├── HydraThemePush.md
│   │   │   ├── HydraThemeSync.md
│   │   ├── aboutHydra.md
│   ├── HydraLife.csproj
│   ├── HydraLife.csproj.user
│   ├── HydraLife.sln
│   📁 LoginSystem/
│   │   ├── LoginForm.Designer.cs
│   │   ├── LoginForm.cs
│   │   ├── LoginForm.resx
│   │   ├── LoginPanel.Designer.cs
│   │   ├── LoginPanel.cs
│   │   ├── LoginPanel.resx
│   │   ├── VirtualDesktopForm.Designer.cs
│   │   ├── VirtualDesktopForm.cs
│   │   ├── VirtualDesktopForm.resx
│   📁 Modules/
│   │   📁 Ceremony/
│   │   │   ├── HydraMoodCycler.cs
│   │   │   ├── HydraSpirit.cs
│   │   📁 Functions/
│   │   │   ├── ExButton.cs
│   │   📁 Helpers/
│   │   │   ├── EmpathicPause.cs
│   │   │   ├── HydraTerminal.cs
│   │   ├── HydraLauncher.cs
│   │   ├── HydraTerminalConfig.cs
│   │   ├── HydraThemeManager.cs
│   │   📁 Lexicon/
│   │   │   ├── HydraLexiconReporter.cs
│   │   📁 Media/
│   │   │   ├── HydraMediaLexicon.cs
│   │   📁 Stage/
│   │   │   ├── HydraStageManager.cs
│   │   📁 Themes/
│   │   │   ├── ThemeManifest.cs
│   │   📁 Ui/
│   │   │   ├── SplashScreenManager.cs
│   │   📁 Voice/
│   │   │   ├── HydraVoice.cs
│   ├── Program.cs
│   📁 Properties/
│   │   ├── AssemblyInfo.cs
│   │   ├── Resources.Designer.cs
│   │   ├── Resources.resx
│   │   ├── Settings.Designer.cs
│   │   ├── Settings.settings
│   📁 Resources/
│   │   ├── 25706.png
│   │   ├── 493-4933495_close-button-png-transparent-image-close-icon-png.png
│   │   ├── 493-4933495_close-button-png-transparent-image-close-icon-png1.png
│   │   ├── End messaging session.png
│   │   ├── System reboot (1).png
│   │   ├── System reboot (1)1.png
│   │   ├── System reboot.png
│   │   ├── Technical_Support.jpg
│   │   ├── Tray arrow up.png
│   │   ├── Window minimize.png
│   │   ├── close.png
│   │   ├── eu.jpg
│   │   ├── hercaclitus.jpg
│   │   ├── hercaclitus1.jpg
│   │   ├── hercaclitus2.jpg
│   │   ├── hercaclitus3.jpg
│   │   ├── hydra.png
│   │   ├── img.png
│   │   ├── logout.png
│   │   ├── material.png
│   │   ├── power-button-off.png
│   │   ├── power-on.png
│   │   ├── reload.png
│   │   ├── reset.png
│   │   ├── switch.png
│   │   ├── switch1.png
│   │   ├── transferir.png
│   │   ├── transferir1.png
│   📁 bin/
│   │   📁 Debug/
│   │   │   ├── LifeCicles.exe
│   │   │   ├── LifeCicles.exe.config
│   │   │   ├── LifeCicles.pdb
│   │   │   ├── Microsoft.Bcl.AsyncInterfaces.dll
│   │   │   ├── Microsoft.Bcl.AsyncInterfaces.xml
│   │   │   ├── Newtonsoft.Json.dll
│   │   │   ├── Newtonsoft.Json.xml
│   │   │   ├── System.Buffers.dll
│   │   │   ├── System.Buffers.xml
│   │   │   ├── System.IO.Pipelines.dll
│   │   │   ├── System.IO.Pipelines.xml
│   │   │   ├── System.IO.Ports.dll
│   │   │   ├── System.IO.Ports.xml
│   │   │   ├── System.Memory.dll
│   │   │   ├── System.Memory.xml
│   │   │   ├── System.Numerics.Vectors.dll
│   │   │   ├── System.Numerics.Vectors.xml
│   │   │   ├── System.Runtime.CompilerServices.Unsafe.dll
│   │   │   ├── System.Runtime.CompilerServices.Unsafe.xml
│   │   │   ├── System.Text.Encodings.Web.dll
│   │   │   ├── System.Text.Encodings.Web.xml
│   │   │   ├── System.Text.Json.dll
│   │   │   ├── System.Text.Json.xml
│   │   │   ├── System.Threading.Tasks.Extensions.dll
│   │   │   ├── System.Threading.Tasks.Extensions.xml
│   │   │   ├── System.ValueTuple.dll
│   │   │   ├── System.ValueTuple.xml
│   ├── hydra.ico
│   📁 obj/
│   │   📁 Debug/
│   │   │   ├── DesignTimeResolveAssemblyReferences.cache
│   │   │   ├── DesignTimeResolveAssemblyReferencesInput.cache
│   │   │   ├── HydraLife.SplashScreen.resources
│   │   │   ├── HydraLife.csproj.AssemblyReference.cache
│   │   │   ├── HydraLife.csproj.CoreCompileInputs.cache
│   │   │   ├── HydraLife.csproj.FileListAbsolute.txt
│   │   │   ├── HydraLife.csproj.GenerateResource.cache
│   │   │   ├── HydraLife.csproj.ResolveComReference.cache
│   │   │   ├── HydraLife.csproj.Up2Date
│   │   │   ├── Interop.MediaPlayer.dll
│   │   │   ├── Interop.WMPDXMLib.dll
│   │   │   ├── Interop.WMPLib.dll
│   │   │   ├── LifeCicles.Boot_System.LoginForm.resources
│   │   │   ├── LifeCicles.LoginSystem.LoginPanel.resources
│   │   │   ├── LifeCicles.LoginSystem.VirtualDesktopForm.resources
│   │   │   ├── LifeCicles.Properties.Resources.resources
│   │   │   ├── LifeCicles.exe
│   │   │   ├── LifeCicles.exe.config
│   │   │   ├── LifeCicles.pdb
│   │   │   📁 TempPE/
│   │   │   │   ├── Properties.Resources.Designer.cs.dll
│   │   📁 Release/
│   │   │   ├── HydraLife.csproj.AssemblyReference.cache
│   📁 packages/
│   │   📁 DocumentFormat.OpenXml.3.3.0/
│   │   │   ├── DocumentFormat.OpenXml.3.3.0.nupkg
│   │   │   ├── README.md
│   │   │   ├── icon.png
│   │   │   📁 lib/
│   │   │   │   📁 net35/
│   │   │   │   │   ├── DocumentFormat.OpenXml.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.xml
│   │   │   │   📁 net40/
│   │   │   │   │   ├── DocumentFormat.OpenXml.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.xml
│   │   │   │   📁 net46/
│   │   │   │   │   ├── DocumentFormat.OpenXml.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.xml
│   │   │   │   📁 net8.0/
│   │   │   │   │   ├── DocumentFormat.OpenXml.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.xml
│   │   │   │   📁 netstandard2.0/
│   │   │   │   │   ├── DocumentFormat.OpenXml.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.xml
│   │   📁 DocumentFormat.OpenXml.Framework.3.3.0/
│   │   │   ├── DocumentFormat.OpenXml.Framework.3.3.0.nupkg
│   │   │   ├── README.md
│   │   │   ├── icon.png
│   │   │   📁 lib/
│   │   │   │   📁 net35/
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.xml
│   │   │   │   📁 net40/
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.xml
│   │   │   │   📁 net46/
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.xml
│   │   │   │   📁 net6.0/
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.xml
│   │   │   │   📁 net8.0/
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.xml
│   │   │   │   📁 netstandard2.0/
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.dll
│   │   │   │   │   ├── DocumentFormat.OpenXml.Framework.xml
│   │   📁 Newtonsoft.Json.13.0.4/
│   │   │   ├── LICENSE.md
│   │   │   ├── Newtonsoft.Json.13.0.4.nupkg
│   │   │   ├── README.md
│   │   │   📁 lib/
│   │   │   │   📁 net20/
│   │   │   │   │   ├── Newtonsoft.Json.dll
│   │   │   │   │   ├── Newtonsoft.Json.xml
│   │   │   │   📁 net35/
│   │   │   │   │   ├── Newtonsoft.Json.dll
│   │   │   │   │   ├── Newtonsoft.Json.xml
│   │   │   │   📁 net40/
│   │   │   │   │   ├── Newtonsoft.Json.dll
│   │   │   │   │   ├── Newtonsoft.Json.xml
│   │   │   │   📁 net45/
│   │   │   │   │   ├── Newtonsoft.Json.dll
│   │   │   │   │   ├── Newtonsoft.Json.xml
│   │   │   │   📁 net6.0/
│   │   │   │   │   ├── Newtonsoft.Json.dll
│   │   │   │   │   ├── Newtonsoft.Json.xml
│   │   │   │   📁 netstandard1.0/
│   │   │   │   │   ├── Newtonsoft.Json.dll
│   │   │   │   │   ├── Newtonsoft.Json.xml
│   │   │   │   📁 netstandard1.3/
│   │   │   │   │   ├── Newtonsoft.Json.dll
│   │   │   │   │   ├── Newtonsoft.Json.xml
│   │   │   │   📁 netstandard2.0/
│   │   │   │   │   ├── Newtonsoft.Json.dll
│   │   │   │   │   ├── Newtonsoft.Json.xml
│   │   │   ├── packageIcon.png
│   ├── packages.config
├── README.md
📁 Screenshots/
│   ├── application_started.png
│   ├── check_files_emulator.png
│   ├── shuting_down.png
│   ├── shuting_down2.png
├── changelog_changes.py
├── generate_tree.py
📁 plan/
│   ├── Gantt.xlsx
│   ├── HydraSessionResume.md
│   ├── currentStatusGanttChart.md
├── requirements.txt
├── tree_text
```

<!-- Project tree ends here -->


</details>

---

## 📝 **Additional notes**
 <!-- ... [ADD ADDITIONAL NOTES] -->
## This project was created in close colaboration with Microsoft Copilot(🤖), to who a leave special thanks and apreciation.

---

## 📸 Screenshots

<details>
  <summary>Clique para ver as capturas cerimoniais</summary>
```
  <p>Estamos atualmente a desenvolver uma splash screen que mimetiza o bootloader do Windows 8.1 e saída terminal estilo Linux.</p>

  <div align="center"> 
    <img src="Screenshots/application_started.png" width="300"/>
    <img src="Screenshots/check_files_emulator.png" width="300"/>
    <img src="Screenshots/shuting_down.png" width="300"/>
    <img src="Screenshots/shuting_down2.png" width="300"/>
  </div>

``
</details>

---

## 🍰 **Supporters and donators**

<!-- Change your small logo -->
<a href="https://github.com/carloshmarques/HydraLife">
  <img alt="@carloshmarques/HydraLife's brand logo without text" align="right" src="https://imgur.com/kits5mj.png" width="14%" />
</a>

### 🙌 Special Thanks
- Microsoft Copilot 🤖 — for collaborative support and inspiration
- Josee9988 — for the original project template

Want to support HydraLife? Become a donor and get featured here!



We are currently looking for new donators to help and maintain this project! ❤️

By donating, you will help the development of this project, and *you will be featured in this HydraLife's README.md*, so everyone can see your kindness and visit your content ⭐.

<a href="https://github.com/sponsors/carloshmarques"> <!-- MODIFY THIS LINK TO YOUR MAIN DONATING SITE IF YOU ARE NOT IN THE GITHUB SPONSORS PROGRAM -->
  <img src="https://img.shields.io/badge/Sponsor-carloshmarques/HydraLife-blue?logo=github-sponsors&style=for-the-badge&color=red">
</a>

<!-- LINK TO YOUR DONATING PAGES HERE -->

---

HydraLife was generated from *[Josee9988/project-template](https://github.com/Josee9988/project-template)* 📚

---

## 🕵️ Extra recommendations
 <!-- If you recommend installing anything special, or if you recommend using X thing for the good use of your project...-->
* Uses visual studio(2022)<img align="center" alt="visual studio" height="30" width="50" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/visualstudio/visualstudio-plain.svg" /> at this moment, and <img align="center" alt=".net" height="30" width="50" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" /> .net framework 4.8.
---

## 🎉 Was the "Organizer virtual OS style" helpful? Help us raise these numbers up

[![GitHub followers](https://img.shields.io/github/followers/carloshmarques.svg?style=social)](https://github.com/carloshmarques)
[![GitHub stars](https://img.shields.io/github/stars/carloshmarques/HydraLife.svg?style=social)](https://github.com/carloshmarques/HydraLife/stargazers)
[![GitHub watchers](https://img.shields.io/github/watchers/carloshmarques/HydraLife.svg?style=social)](https://github.com/carloshmarques/HydraLife/watchers)
[![GitHub forks](https://img.shields.io/github/forks/carloshmarques/HydraLife.svg?style=social)](https://github.com/carloshmarques/HydraLife/network/members)
<!-- MODIFY THIS LINK TO YOUR MAIN DONATING SITE IF YOU ARE NOT IN THE GITHUB SPONSORS PROGRAM -->
[![Sponsor](https://img.shields.io/static/v1?label=Sponsor&message=%E2%9D%A4&logo=github-sponsors&color=red&style=social)](https://github.com/sponsors/carloshmarques)

Enjoy! 😃

---

## ⚖️📝 **License and Changelog**

See the license in the '**[LICENSE](LICENSE)**' file.

Watch the changes in the '**[CHANGELOG.md](CHANGELOG.md)**' file.
<!--... [ CHANGELOG changes starts here] -->
<!--... [ CHANGELOG changes ends here] -->

---

_Made with a lot of ❤️❤️ by **[@carloshmarques](https://github.com/carloshmarques)**_

---