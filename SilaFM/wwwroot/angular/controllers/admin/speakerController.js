app.controller('speakerController', function($scope, $http, $compile) {
    $scope.model = model;
    $scope.languages = [
        "абхазский",
        "аварский",
        "австрийский",
        "адыгейский",
        "азербайджанский",
        "албанский",
        "алжирский",
        "амхарский",
        "английский американский",
        "английский британский",
        "английский австралийский",
        "английский ирландский",
        "английский канадский",
        "английский новозеландский",
        "арабский",
        "аравийский",
        "арамейский",
        "армянский",
        "ассамский",
        "ассирийский",
        "афганский",
        "баскский",
        "башкирский",
        "белорусский",
        "бенгальский",
        "бирманский",
        "болгарский",
        "боснийский",
        "бурятский",
        "венгерский",
        "вьетнамский",
        "гаити",
        "гаэльский",
        "голландский",
        "греческий",
        "грузинский",
        "дари (фарси)",
        "датский",
        "еврейский",
        "египетский",
        "Зулу",
        "иврит",
        "идиш",
        "ингушский",
        "индонезийский",
        "испанский латиноамериканский",
        "испанский европейский",
        "испанский каталонский",
        "итальянский",
        "ительменский",
        "Йоруба",
        "кабардино-черкесский",
        "казахский",
        "камбоджийский",
        "киргизский",
        "китайский мандарин",
        "китайский тайвань",
        "китайский кантонезе",
        "креольский",
        "койбальский",
        "коми",
        "корейский",
        "коса",
        "крымскотатарский",
        "курдский",
        "курманджи",
        "лаосский",
        "латышский",
        "латынь",
        "ливийский",
        "литовский",
        "мавританский",
        "мадьярский",
        "малайский",
        "маратхи",
        "марокканский",
        "мегрельский",
        "мокша-мордовский",
        "молдавский",
        "монгольский",
        "мяо",
        "немецкий",
        "немецкий австрия",
        "немецкий швейцария",
        "нидерландский",
        "норвежский",
        "осетинский",
        "панджаби",
        "персидский",
        "польский",
        "португальский бразильский",
        "португальский европейский",
        "пушту",
        "румынский",
        "русский",
        "саамский",
        "сагайский",
        "саха",
        "сартульский",
        "сасигнанский",
        "сванский",
        "сербскохорватский",
        "сесотословенский",
        "сирийско-палестинский",
        "сомали",
        "суахили",
        "суданский",
        "суоми",
        "таджикский",
        "тайванский",
        "тайский",
        "тамильский",
        "татарский",
        "телугу",
        "тунгусский",
        "турецкий",
        "туркменский",
        "удмуртский узбекский",
        "украинский",
        "урду",
        "фарси",
        "финский",
        "фламандский",
        "французский",
        "французский канадский",
        "французский бельгийский",
        "хинди",
        "хорватский",
        "хуфи",
        "цыганский",
        "черкесский",
        "черногорский",
        "чеченский",
        "чешский",
        "чувашский",
        "чукотский",
        "шведский",
        "эстонский",
        "эфиопский",
        "югский",
        "юитский",
        "юкагирский",
        "юртовских татар язык",
        "якутский",
        "японский"
    ];
    $scope.voices = [
        "забавный, прикольный",
        "конферансье, шоу-мен",
        "официальный, властный",
        "яркий, блестящий",
        "живой, оживленный",
        "спокойный, невозмутимый, хладнокровный",
        "театральный, манерный",
        "нахальный, бестактный, наглый",
        "радостный, веселый, энергичный",
        "понятный, доходчивый",
        "комичный, отвязный",
        "уверенный, дока, \"спец\"",
        "общительный, балагуристый",
        "спокойный, неспешный",
        "прямолинейный, четкий",
        "глубокий, насыщенный",
        "dj-джей, диск-жокей, заводила",
        "документальный",
        "драматический, эффектный",
        "сухой, скудный",
        "энергетический, заряжающий",
        "полный запала, задора, энтузиаст",
        "дружелюбно, по-дружески",
        "бандит, гопник, \"отвязный перец\"",
        "тупой, непонятливый",
        "нежный, мягкий",
        "по-девчачьи, с эмоциями",
        "возмутительный, резкий",
        "счастливый, жизнерадостный",
        "настойчивый, навязчивый",
        "мощный, сильный",
        "пародист",
        "интеллигентный, воспитанный",
        "спокойный, расслабленный",
        "зрелый, взрослый",
        "мама-папа, родители",
        "серьезный, \"деловая колбаса\"",
        "решительный, напористый",
        "пафосный",
        "убедительный, настойчивый",
        "шикарный, отпадный, обалденный",
        "язвительный, колкий",
        "обнадеживающий, оптимистичный",
        "расслабленный, без напряга, \"беспонтовый\"",
        "богатый, насыщенный, \"жЫрный\"",
        "обольстительный, манящий, чарующий",
        "сексуальный, страстный",
        "гладкий, плавный",
        "успокаивающий, расслабляющий",
        "изощренный, искушенный, утонченный",
        "задумчивый, внимательный",
        "разносторонний, многогранный, универсальный",
        "чуткий, сердечный, душевный"
    ];
    $scope.types = [
        "радиореклама",
        "видеореклама",
        "оформление эфира",
        "джинглы и распевки голосом",
        "пародии",
        "запись IVR и голосового меню",
        "озвучание рекламных фильмов",
        "трейлеры и анонсы",
        "мультипликационные герои",
        "видеоигры",
        "корпоративное видео",
        "синхронный перевод",
        "запись аудиокниг",
        "обучающее видео",
        "выставки, шоу и презентации",
        "реклама в торговых залах"
    ];
    $scope.industries = [
        "Автосалоны, Автобренды",
        "СТО, Заправки, Автомойки",
        "Компьютеры, Офисная техника, Оргтехника, Аксессуары",
        "Банки, Ипотека, Депозиты, Фонды",
        "Базы отдыха, Загородные отели, Спа-центры",
        "Ремонт, Дизайн, Стройматериалы, Сантехника",
        "Недвижимость, Риэлторы, Строительство",
        "Политика, Выборы",
        "Юридические и Охранные фирмы, Нотариусы, Адвокатские бюро",
        "Продукты питания, Напитки",
        "Казино, Игровые залы, Клубы, Автоматы",
        "Театр, Выставки, Праздники, Фестивали",
        "Кинозалы, Вечеринки, Ночные клубы",
        "Ритуальные службы",
        "Супермаркеты, Торговые центры, Магазины",
        "СМИ, Сайты, Агентства",
        "Спорт, Тренажеры, Фитнесс-центры",
        "Мобильные телефоны и аксессуары",
        "Рестораны, Кафе, Бары, Бистро",
        "Средства связи, Услуги Интернет, IVR",
        "Страхование и Социальные проекты",
        "Архитектура, Строительство, Дизайн",
        "Авиа, Ж/д и др.перевозки, Такси",
        "Стоматология, Фармацевтика",
        "Туризм, путешествия",
        "Мебель для дома и офиса",
        "Бытовая техника и электроника",
        "Детские Товары, Игрушки, Питание",
        "Посуда, Аксессуары",
        "Косметика и Парфюмерия",
        "Салоны красоты, парикмахерские, солярии",
        "Одежда и Обувь",
        "Бухгалтерия, офис",
        "Сельхозпродукция, сельхозтехника",
        "Рекламные программы, Аудиокниги",
        "Образование",
        "Эротика, секс",
        "Ювелирные изделия, украшения и бижютерия",
        "Химчистки и прачечные, бытовая химия"
    ];

    //$scope.editLang = function (e, lang) {
    //    e.preventDefault();
    //    $scope.toEdit = lang;
    //    $scope.listItems = $scope.languages;
    //    $('#modalLang').modal('show');
    //}

    //$scope.addLang = function (e) {
    //    e.preventDefault();
    //    $scope.toEdit = { IsNew: true };
    //    $scope.listItems = $scope.languages;
    //    $('#modalLang').modal('show');
    //}

    //$scope.saveLang = function (lang) {
    //    if ($('#editLang').valid()) {
    //        var toEdit = $scope.model.VoiceLanguages.filter(function (obj) {
    //            return obj === lang;
    //        });

    //        if (!toEdit.length) {
    //            lang.IsNew = false;
    //            $scope.model.VoiceLanguages.push(lang);
    //            $scope.toEdit = {};
    //        } else {
    //            toEdit[0] = lang;
    //        }
    //        $('#modalLang').modal('hide');
    //        $('#editLang').trigger('reset');
    //    }
    //}

    //$scope.deleteLang = function (e, lang) {
    //    e.preventDefault();
    //    if (lang)
    //        $scope.model.VoiceLanguages.splice($scope.model.VoiceLanguages.indexOf(lang), 1);
    //}

    //$scope.editVoice = function (e, voice) {
    //    e.preventDefault();
    //    $scope.toEdit = voice;
    //    $scope.listItems = $scope.voices;
    //    $('#modalVoice').modal('show');
    //}

    //$scope.addVoice = function (e) {
    //    e.preventDefault();
    //    $scope.toEdit = { IsNew: true };
    //    $scope.listItems = $scope.voices;
    //    $('#modalVoice').modal('show');
    //}

    //$scope.saveVoice = function (voice) {
    //    if ($('#editVoice').valid()) {
    //        var toEdit = $scope.model.VoiceCharacteristics.filter(function (obj) {
    //            return obj === voice;
    //        });

    //        if (!toEdit.length) {
    //            voice.IsNew = false;
    //            $scope.model.VoiceCharacteristics.push(voice);
    //            $scope.toEdit = {};
    //        } else {
    //            toEdit[0] = voice;
    //        }
    //        $('#modalVoice').modal('hide');
    //        $('#editVoice').trigger('reset');
    //    }
    //}

    //$scope.deleteVoice = function (e, voice) {
    //    e.preventDefault();
    //    if (voice)
    //        $scope.model.VoiceCharacteristics.splice($scope.model.VoiceCharacteristics.indexOf(voice), 1);
    //}

    $scope.addLang = function (e) {
        e.preventDefault();
        $scope.toEdit = {
            Obj: { IsNew: true },
            List: $scope.languages,
            Array: $scope.model.VoiceLanguages,
            HidePath: true
        };
        $scope.listItems = $scope.languages;
        $('#modalItem').modal('show');
    }

    $scope.addVoice = function (e) {
        e.preventDefault();
        $scope.toEdit = { Obj: { IsNew: true }, List: $scope.voices, Array: $scope.model.VoiceCharacteristics };
        $scope.listItems = $scope.voices;
        $('#modalItem').modal('show');
    }

    $scope.addType = function (e) {
        e.preventDefault();
        $scope.toEdit = { Obj: { IsNew: true }, List: $scope.types, Array: $scope.model.VoiceWorkTypes };
        $scope.listItems = $scope.types;
        $('#modalItem').modal('show');
    }

    $scope.addIndustry = function (e) {
        e.preventDefault();
        $scope.toEdit = { Obj: { IsNew: true }, List: $scope.industries, Array: $scope.model.VoiceIndustries };
        $scope.listItems = $scope.industries;
        $('#modalItem').modal('show');
    }
    $scope.addVideo = function (e) {
        e.preventDefault();
        $scope.toEdit = { Obj: { IsNew: true }, Array: $scope.model.ListVideos };
        $scope.listItems = null;
        $('#modalItem').modal('show');
    }

    $scope.editItem = function (e, item, list, array) {
        e.preventDefault();
        $scope.toEdit = { Obj: item, List: list, Array: array };
        $scope.listItems = list;
        $('#modalItem').modal('show');
    }

    $scope.editLang = function (e, item, list, array) {
        e.preventDefault();
        $scope.toEdit = { Obj: item, List: list, Array: array, HidePath: true };
        $scope.listItems = list;
        $('#modalItem').modal('show');
    }

    $scope.saveItem = function (item) {
        if ($('#editItem').valid()) {
            var toEdit = item.Array.filter(function (obj) {
                return obj === item.Obj;
            });

            if (!toEdit.length) {
                item.Obj.IsNew = false;
                item.Array.push(item.Obj);
                $scope.toEdit = {};
            } else {
                toEdit[0] = item.Obj;
            }
            $('#modalItem').modal('hide');
            $('#editItem').trigger('reset');
        }
    }

    $scope.deleteItem = function (e, item, array) {
        e.preventDefault();
        if (item)
            array.splice(array.indexOf(item), 1);
    }


    $scope.loadElfinder = function (id) {
        return loadElfinder(id);
    }
});