# Pre správne fungovanie je treba stiahnuť nasledujúce programy a rozšírenia
# GNU Make 	http://gnuwin32.sourceforge.net/packages/make.htm
# GNU Zip  	http://gnuwin32.sourceforge.net/packages/zip.htm
# Doxygen  	http://www.doxygen.nl/download.html
# Advanced installer: https://www.advancedinstaller.com/download.html	(pre zkompilovanie setupu pre inštaláciu kalkulačky)

# nastavenie premenných s cestami
ROOT_DIR:=$(shell cd)\..
VISUAL_STUDIO_PATH=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community
PROJ_NAME=Calculator
PROJ_DIR=$(ROOT_DIR)\src\Kalkulator
PROJ="$(PROJ_DIR)\bin\Release\(j)Elitná kalkulačka.exe"
PROJ_FILE=$(PROJ_DIR)\$(PROJ_NAME).csproj
TESTS_DIR=$(ROOT_DIR)\src\Tests
PROF_DIR_NAME=StandardDeviation
PROF_NAME=StandardDeviation
PROF_DIR=$(ROOT_DIR)\src\$(PROF_DIR_NAME)
PROF=$(PROF_DIR)\bin\Debug\$(PROF_NAME).exe
PROF_FILE=$(PROF_DIR)\$(PROF_NAME).csproj

# premenné pre zabalenie archívu
PACK_NAME=xzatko02_xrakus04_xjacol00_xkubin24
PACK_ARCHIVE=$(ROOT_DIR)\$(PACK_NAME).zip
PACK_DIR:=$(ROOT_DIR)\..\$(PACK_NAME)
PACK_DOC_DIR=$(PACK_DIR)\doc
PACK_INSTALL_DIR=$(PACK_DIR)\install
PACK_REPO_DIR=$(PACK_DIR)\repo

# cesta k dokumentácii
DOC_OUTPUT_DIR=$(ROOT_DIR)\src\doxygen_out

# premenné a cesty pre profiling
PROFILING_NAME=StandardDeviation
PROFILING_DIR=$(ROOT_DIR)\src\$(PROFILING_NAME)

# jednoduchý inštalátor
INSTALLER_NAME=Setup
INSTALLER_FILE=$(ROOT_DIR)\src\$(INSTALLER_NAME).exe

.PHONY: all build pack clean doc run

####### Zostavenie riešenia a následné spustenie
all: build run

####### Zostavenie riešenia - kalkulačka a profiling#####################
build:
	cd "$(VISUAL_STUDIO_PATH)" & $(MSBUILD) "$(PROJ_FILE)" /t:Build /p:Configuration=Release
	cd "$(VISUAL_STUDIO_PATH)" & $(MSBUILD) "$(PROF_FILE)" /t:Build /p:Configuration=Release

####### Spustenie programu ##############################################
run:
	if not exist "$(PROJ)" make build
	$(PROJ)
	
####### Vytvorenie dokumentácie do zložky definovanej v Doxyfile ########
doc: Doxyfile
	doxygen $<

####### Zmaže súbory pred odovzdaním #####################################
clean:
	if exist "$(ROOT_DIR_C)\.vs" rmdir "$(ROOT_DIR_C)\.vs" /q /s
	if exist "$(DOC_OUTPUT_DIR)" rmdir "$(DOC_OUTPUT_DIR)" /q /s
	if exist "$(PROJ_DIR)\bin" rmdir "$(PROJ_DIR)\bin" /q /s
	if exist "$(PROJ_DIR)\obj" rmdir "$(PROJ_DIR)\obj" /q /s
	if exist "$(TESTS_DIR)\bin" rmdir "$(TESTS_DIR)\bin" /q /s
	if exist "$(TESTS_DIR)\obj" rmdir "$(TESTS_DIR)\obj" /q /s
	if exist "$(PROFILING_DIR)\bin" rmdir "$(PROFILING_DIR)\bin" /q /s
	if exist "$(PROFILING_DIR)\obj" rmdir "$(PROFILING_DIR)\obj" /q /s

####### Vykonanie profilingu #############################################
profile: <data.txt
	cd $(PROF_DIR)\bin\Debug
	if not exist "$(PROF)" make build
	$(PROF) $<

ROOT_DIR_C:=$(shell cd)

####### Zabalenie súborov pre odovzdanie
pack: doc build
	if exist "$(PACK_DIR)" del "$(PACK_DIR)" /f /s /q 1>nul & rmdir "$(PACK_DIR)" /s /q
	mkdir "$(PACK_DIR)"

	mkdir "$(PACK_DOC_DIR)"
	xcopy /s "$(DOC_OUTPUT_DIR)\html" "$(PACK_DOC_DIR)"

	mkdir "$(PACK_REPO_DIR)"
	xcopy /s "$(ROOT_DIR)" "$(PACK_REPO_DIR)"

	mkdir "$(PACK_INSTALL_DIR)"
	xcopy /s "$(INSTALLER_FILE)" "$(PACK_INSTALL_DIR)"

	cd "$(PACK_DIR)\.." & zip -r "$(PACK_ARCHIVE)" $(PACK_NAME)
	del "$(PACK_DIR)" /f /s /q 1>nul
	rmdir "$(PACK_DIR)" /s /q


####### Nápoveda #########################################################
help:
	@echo make all (prelozi a spusti program)
	@echo pack (zabali projekt tak, aby mohol byt odevzdany)
	@echo clean (zmaze vsetky subory, co nemaju byt odevzdane)
	@echo run (spusti program)
	@echo profile (spusti program pre vypocet smerodatnej odchylky s ukazkovym testovacim vstupem - data.txt)