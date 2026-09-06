# Selenium BDD Test Automation Framework

A BDD-style test automation framework built in **.NET 6**, designed to validate web application behaviour through executable requirements. It uses **Selenium WebDriver** for UI automation and **RestSharp** for API validation, with a focus on readable, maintainable end-to-end testing.

---

## Project Purpose

This framework validates web application behaviour using human-readable, executable specifications written in Gherkin. It's designed for:

- **Readable automation** — tests double as living documentation
- **Maintainable structure** — clear separation of concerns across layers
- **End-to-end coverage** — both UI (Selenium) and API (RestSharp) validation

---

## AI Agentic Workflows

This project was built using **Claude Code** as an AI-assisted development environment, with the workflow structured around agentic principles rather than ad-hoc prompting.

- **Persistent context (`CLAUDE.md`)** — A project-root configuration file capturing conventions, structure, and standards, so context carried across every session instead of being re-explained each time.
- **Specialized subagents** — The work was broken into focused subagents, including:
  - A subagent dedicated to writing and maintaining Selenium **page-object classes**
  - A subagent focused on **test case generation and assertions**
- **Reusable skills** — Defined for repetitive tasks such as generating boilerplate code and implementing consistent **wait strategies**, avoiding repeated manual instruction for common patterns.

---

## Tech Stack

| Category | Technology |
|---|---|
| Language | C# |
| Framework | .NET |
| UI Automation | Selenium WebDriver |
| API Automation | RestSharp |
| Test Style | BDD (Behaviour-Driven Development) |

**Project structure includes:** `Features`, `StepDefinitions`, `Hooks`, `Utilities`, and support for configuration and validation data.

---

## High-Level Architecture & Design

### Behaviour-Driven Tests
Scenarios are written in plain, human-readable language, describing expected application behaviour as executable specifications.

### Layered Design
```
Feature Files  →  Step Definitions  →  Page Objects / Actions  →  Utilities
   (Gherkin)         (glue code)         (UI interactions)      (logging, config, screenshots)
```

### Hooks
- **Before/After scenario hooks** manage setup and teardown
- **Driver lifecycle management** ensures clean browser sessions per test
- **Automatic screenshot capture on failure** for easier debugging

### Utilities
Centralized, reusable responsibilities that keep step definitions concise:
- 📸 Screenshot handling
- ⚙️ Configuration reads
- ⏱️ Wait helpers
- 🚗 WebDriver management

---

## Project Structure

```
├── Features/            # Gherkin feature files (executable specifications)
├── StepDefinitions/      # Step implementation / glue code
├── PageObjects/          # Page Object Model classes
├── Hooks/                # Before/After scenario hooks
├── Utilities/            # Logging, screenshots, config, wait helpers
└── CLAUDE.md             # Project context for AI-assisted development
```

---

## ✅ Getting Started

> _Add setup instructions here — e.g. prerequisites, how to restore dependencies, how to run tests._

```bash
dotnet restore
dotnet test
```

---

## 📄 License

> _Add your license here._
