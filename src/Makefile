# pro spravne fungovani je treba stahnout nasledujici programy/rozsireni
# GNU Make 	http://gnuwin32.sourceforge.net/packages/make.htm	(rozsireni cmd, funkce make)
# GNU Zip  	http://gnuwin32.sourceforge.net/packages/zip.htm	(rozsireni cmd, funkce zip)
# Doxygen  	http://www.doxygen.nl/download.html			(rozsireni cmd, generovani dokumentace)
# INNO Setup	https://jrsoftware.org/isdl.php				(pro zkompilovani setup pro instalaci kalkulacky)

# nastaveni promennych
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

# promenne pro zabaleni archivu
PACK_NAME=xzatko02_xrakus04_xjacol00_xkubin24
PACK_ARCHIVE=$(ROOT_DIR)\$(PACK_NAME).zip
PACK_DIR:=$(ROOT_DIR)\..\$(PACK_NAME)
PACK_DOC_DIR=$(PACK_DIR)\doc
PACK_INSTALL_DIR=$(PACK_DIR)\install
PACK_REPO_DIR=$(PACK_DIR)\repo

# cesta k dokumentaci
DOC_OUTPUT_DIR=$(ROOT_DIR)\src\doxygen_out

# jednoduchy instalator
INSTALLER_NAME=Setup
INSTALLER_FILE=$(ROOT_DIR)\src\$(INSTALLER_NAME).exe

# promenne a cesty pro profiling
PROFILING_NAME=StandardDeviation
PROFILING_DIR=$(ROOT_DIR)\src\$(PROFILING_NAME)

.PHONY: all build pack clean doc run

####### 1 sestavit reseni a nasledne spustit
all: build run

####### 2 sestavit reseni (kalkulacka, profiling)
build:
	cd "$(VISUAL_STUDIO_PATH)" & $(MSBUILD) "$(PROJ_FILE)" /t:Build /p:Configuration=Release
	cd "$(VISUAL_STUDIO_PATH)" & $(MSBUILD) "$(PROF_FILE)" /t:Build /p:Configuration=Release

####### 3 spustit program
run:
	if not exist "$(PROJ)" make build
	$(PROJ)

####### 4 vytvorit dokumentaci (do slozky definovane v Doxyfile)
doc: Doxyfile
	doxygen $<

####### 5 zabalit soubory pro odevzdani (vytvori na plose pomocnou slozku s nasimi jmeny, zabali ji, presune do "*\ivs_project_2_2020", a slozku na plose smaze)
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

####### 6 profiling
profile: <profiling_input.txt
	cd $(PROF_DIR)\bin\Debug
	if not exist "$(PROF)" make build
	$(PROF) $<

ROOT_DIR_C:=$(shell cd)
####### 7 smazat soubory pred odevzdanim
clean:
	if exist "$(ROOT_DIR_C)\.vs" rmdir "$(ROOT_DIR_C)\.vs" /q /s
	if exist "$(DOC_OUTPUT_DIR)" rmdir "$(DOC_OUTPUT_DIR)" /q /s
	if exist "$(PROJ_DIR)\bin" rmdir "$(PROJ_DIR)\bin" /q /s
	if exist "$(PROJ_DIR)\obj" rmdir "$(PROJ_DIR)\obj" /q /s
	if exist "$(TESTS_DIR)\bin" rmdir "$(TESTS_DIR)\bin" /q /s
	if exist "$(TESTS_DIR)\obj" rmdir "$(TESTS_DIR)\obj" /q /s
	if exist "$(PROFILING_DIR)\bin" rmdir "$(PROFILING_DIR)\bin" /q /s
	if exist "$(PROFILING_DIR)\obj" rmdir "$(PROFILING_DIR)\obj" /q /s

####### 8 napoveda
help:
	@echo 1. make all (prelozi a spusti program)
	@echo 2. pack (zabali projekt tak, aby mohl byt odevzdan)
	@echo 3. clean (smaze vsechny soubory, co nemaji byt odevzdany)
	@echo 4. run (spusti program)
	@echo 5. profile (spusti program pro vypocet smerodatne odchylky s ukazkovym testovacim vstupem)