package com.jetbrains.rider.plugins.testlinker2

import com.jetbrains.rider.settings.simple.SimpleOptionsPage

class OptionsPage : SimpleOptionsPage("Test Linker 2 Options", "OptionsPage") {
    override fun getId(): String {
        return "Test Linker 2 Options"
    }
}