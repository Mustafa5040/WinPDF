# WinPDF 📄✨

A lightweight, modern PDF reader and viewer designed natively for Windows 11 using **WinUI 3**, **Windows App SDK**, and **.NET 9**. 

WinPDF leverages native Windows desktop capabilities, offering a fluent interface with dynamic Mica backdrops, multi-document tabbed navigation, drag-and-drop support, and hardware-accelerated PDF rendering.

> ⚠️ **Status**: **Work in Progress (Active Development)**  
> Core viewer, tab architecture, and drag-and-drop operations are implemented. Annotation, deep search, and AI-driven document features are planned.

---

## 🌟 Highlights & Current Features

* **Fluent Windows 11 Design System**:
  * Native custom TitleBar integration (`ExtendsContentIntoTitleBar`).
  * Dynamic **Mica / Mica Alt** system backdrop with theme-aware configuration (`SystemBackdropConfiguration`).
* **Multi-Tabbed Workspace**:
  * Tabbed document interface powered by `TabView` and MVVM architecture.
  * Dedicated Home tab for quick actions and separate, isolated tabs for loaded PDFs.
* **Native PDF Rendering Pipeline**:
  * Utilizes the native `Windows.Data.Pdf.PdfDocument` API.
  * Streams page bitmaps directly via `InMemoryRandomAccessStream` for smooth vertical scrolling using `ItemsRepeater`.
  * Zoom and pan gestures supported via `ScrollView` manipulation modes.
* **Drag-and-Drop & Picker Workflows**:
  * Full drag-and-drop capability from Windows File Explorer directly onto the canvas or Home view.
  * Asynchronous file pickers supporting single and multiple document loading.
* **MVVM Architecture**:
  * Built using **CommunityToolkit.Mvvm** (`ObservableObject`, `IRelayCommand`, custom event/drag-drop contexts).

---

## 📸 Architecture & UI Overview

```
                      +-----------------------------+
                      |   MainWindow (Mica/Tabs)    |
                      +--------------+--------------+
                                     |
               +---------------------+---------------------+
               |                                           |
               v                                           v
      +-----------------+                         +-----------------+
      |    HomePage     |                         |     PDFPage     |
      | (Quick Actions, |                         | (Document View, |
      |  File Picker,   |                         |  ItemsRepeater, |
      |  Drag-and-Drop) |                         |  Page Nav Tree) |
      +-----------------+                         +--------+--------+
                                                           |
                                                           v
                                              +-------------------------+
                                              |    PDFRenderer Engine   |
                                              |  (Windows.Data.Pdf ->   |
                                              |     Bitmap Streams)     |
                                              +-------------------------+
```

---

## 🛠️ Tech Stack & Dependencies

* **Platform**: Windows App SDK (WinUI 3)
* **Framework**: .NET 9.0 (`net9.0-windows10.0.26100.0`)
* **Libraries & Packages**:
  * `CommunityToolkit.Mvvm` (8.4.0) — Modern MVVM patterns
  * `Microsoft.WindowsAppSDK` (1.7.x) — Modern Windows desktop controls & runtime
  * `Microsoft.Graphics.Win2D` (1.3.2) — Hardware-accelerated graphics
  * `Microsoft.Xaml.Behaviors.WinUI.Managed` (3.0.0) — XAML Interaction & Behaviors

---

## 📁 Project Structure

```
WinPDF/
├── App.xaml / .cs               # Application entry point & resource definitions
├── MainWindow.xaml / .cs        # Root window, Mica backdrop & TabView management
├── Helpers/                     # Win32 Dispatcher Queue helpers
├── Models/                      # Tab, Document, and Event Context data structures
├── Services/
│   ├── FileOperationService.cs  # Windows Storage Pickers wrapper
│   ├── InteractionServices.cs   # Dialog & notification services
│   ├── NavigationService.cs     # Frame navigation logic
│   └── PDFRenderer.cs           # PDF stream decoding and bitmap conversion
├── ViewModels/
│   ├── MainViewModel.cs         # Tab collection and tab lifecycle commands
│   ├── HomeViewModel.cs         # Drag-and-drop and document open workflows
│   └── TabViewModel.cs          # Tab metadata and encapsulated Frame states
└── Views/
    ├── HomePage.xaml            # Welcome screen with drop target
    └── PDFPage.xaml             # PDF document view & section tree panel
```

---

## 🚀 Getting Started

### Prerequisites
* Windows 10 (Version 1809 / Build 17763 or newer) or **Windows 11** (Recommended).
* Visual Studio 2022 (v17.12+) with:
  * **.NET Desktop Development** workload.
  * **Windows App SDK C# Templates** installed.

### Build and Run
1. Clone this repository:
   ```bash
   git clone https://github.com/yourusername/WinPDF.git
   ```
2. Open `WinPDF.sln` in Visual Studio.
3. Select your platform target (`x64`, `ARM64`, or `x86`) and build configuration (`Debug` or `Release`).
4. Set `WinPDF (Package)` or `WinPDF (Unpackaged)` as the startup project and press **F5**.

---

## 🗺️ Roadmap

- [x] Multi-tabbed window infrastructure (`TabView`).
- [x] Mica & Mica Alt system backdrop support.
- [x] Native PDF decoding into virtualized image repeaters.
- [x] Drag & drop integration for document loading.
- [ ] Table of contents / Bookmarks extraction into the sidebar `TreeView`.
- [ ] Text extraction, selection, and in-document search.
- [ ] Highlight and annotation tools.
- [ ] Document summarization with AI integration.

---

## 📄 License

This project is licensed under the [GNU General Public License v3.0](LICENSE).