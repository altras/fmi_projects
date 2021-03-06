var xmlDoc = new ActiveXObject("Microsoft.XMLDOM");

var ServerSettings = xmlDoc.createElement('ServerSettings');
xmlDoc.appendChild(ServerSettings)

	var Weapons = xmlDoc.createElement('Weapons');
	
		var Name = xmlDoc.createElement('Name');
		Weapons.appendChild(Name);
			var Range = xmlDoc.createElement('Range');
			Name.appendChild(Range);
			var Damage = xmlDoc.createElement('Damage');
			Name.appendChild(Damage);
			var Animation = xmlDoc.createElement('Animation');
			Name.appendChild(Animation);
			var Animation = xmlDoc.createElement('Animation');
			Name.appendChild(Animation);
			var FireSpeed = xmlDoc.createElement('FireSpeed');
			Name.appendChild(FireSpeed);
			var AmmoSpeed = xmlDoc.createElement('AmmoSpeed');
			Name.appendChild(AmmoSpeed);
			var Scatter = xmlDoc.createElement('Scatter');
			Name.appendChild(Scatter);
			var Shots = xmlDoc.createElement('Shots');
			Name.appendChild(Shots);
	var Server = xmlDoc.createElement('Server');
	ServerSettings.appendChild(Server);
		var Administrator = xmlDoc.createElement('Administrator');
		Server.appendChild(Administrator);
			var Email = xmlDoc.createElement('Email');
			Administrator.appendChild(Email);
		var Webpage = xmlDoc.createElement('Webpage');
		Server.appendChild(Webpage);
		var WelcomeMessage = xmlDoc.createElement('WelcomeMessage');
		Server.appendChild(WelcomeMessage);
		var PunkBuster = xmlDoc.createElement('PunkBuster');
		Server.appendChild(PunkBuster);
		var AllowVotes = xmlDoc.createElement('AllowVotes');
		Server.appendChild(AllowVotes);
		var GameType = xmlDoc.createElement('GameType');
		Server.appendChild(GameType);
		var CaptureLimit = xmlDoc.createElement('CaptureLimit');
		Server.appendChild(CaptureLimit);
		var TimeLimit = xmlDoc.createElement('TimeLimit');
		Server.appendChild(TimeLimit);
		var FragLimit = xmlDoc.createElement('FragLimit');
		Server.appendChild(FragLimit);
	var Maps = xmlDoc.createElement('Maps');
	ServerSettings.appendChild(Maps);
		var Map = xmlDoc.createElement('Map');
		Maps.appendChild(Map);
			var Gravity = xmlDoc.createElement('Gravity');
			Map.appendChild(Gravity);
			var ArmorRespawn = xmlDoc.createElement('ArmorRespawn');
			Map.appendChild(ArmorRespawn);
			var MegaRespawn = xmlDoc.createElement('MegaRespawn');
			Map.appendChild(MegaRespawn);
			var QuadRespawn = xmlDoc.createElement('QuadRespawn');
			Map.appendChild(QuadRespawn);
			var HealthRespawn = xmlDoc.createElement('HealthRespawn');
			Map.appendChild(HealthRespawn);
			var WeaponRespawn = xmlDoc.createElement('WeaponRespawn');
			Map.appendChild(WeaponRespawn);
			var AmmoRespawn = xmlDoc.createElement('AmmoRespawn');
			Map.appendChild(AmmoRespawn);
			var MinPlayers = xmlDoc.createElement('MinPlayers');
			Map.appendChild(MinPlayers);
	var Bots = xmlDoc.createElement('Bots');
	ServerSettings.appendChild(Bots);
		var Bot = xmlDoc.createElement('Bot');
		Bots.appendChild(Bot);
			var Accuracy = xmlDoc.createElement('Accuracy');
			Bot.appendChild(Accuracy);


// attributes

Name.setAttribute('alias', 'Пушка');
Name.setAttribute('name', 'MachineGun');
Administrator.setAttribute('name','Виталий Филипов');
Map.setAttribute('name','q3_2.dm');
Bot.setAttribute('name','Бойко Борисов');
Bot.setAttribute('difficulty','труден');

// nodes

var обсег = xmlDoc.createTextNode('1000');
	Range.appendChild(обсег);

var щети = xmlDoc.createTextNode('40');
	Damage.appendChild(щети);

var анимация = xmlDoc.createTextNode('MachineGun');
	Animation.appendChild(анимация);

var стрелба = xmlDoc.createTextNode('50');
	FireSpeed.appendChild(стрелба);

var бързина = xmlDoc.createTextNode('100');
	AmmoSpeed.appendChild(бързина);

var разсейка = xmlDoc.createTextNode('0');
	Scatter.appendChild(разсейка);

var куршуми = xmlDoc.createTextNode('1');
	Shots.appendChild(куршуми);

var имейл = xmlDoc.createTextNode('altras@gmail.com');
	Email.appendChild(имейл);

var уебстраница = xmlDoc.createTextNode('www.fb.com');
	Webpage.appendChild(уебстраница);

var съобщение = xmlDoc.createTextNode('Здравейте! Днес е хубав ден за игра :)');
	WelcomeMessage.appendChild(съобщение);

var пънк = xmlDoc.createTextNode('yes');
	PunkBuster.appendChild(пънк);

var вот = xmlDoc.createTextNode('no');
	AllowVotes.appendChild(вот);

var тип = xmlDoc.createTextNode('умирай трудно');
	GameType.appendChild(тип);

var лимит = xmlDoc.createTextNode('50');
	CaptureLimit.appendChild(лимит);

var време = xmlDoc.createTextNode('20');
	TimeLimit.appendChild(време);

var гравитация = xmlDoc.createTextNode('1');
	Gravity.appendChild(гравитация);

var броня = xmlDoc.createTextNode('2');
	ArmorRespawn.appendChild(броня);

var мегаживот = xmlDoc.createTextNode('2');
	MegaRespawn.appendChild(мегаживот);

var мегащети = xmlDoc.createTextNode('2');
	QuadRespawn.appendChild(мегащети);

var живот = xmlDoc.createTextNode('3');
	HealthRespawn.appendChild(живот);

var оръжие = xmlDoc.createTextNode('1');
	WeaponRespawn.appendChild(оръжие);

var муниции = xmlDoc.createTextNode('3');
	AmmoRespawn.appendChild(муниции);

var играчи = xmlDoc.createTextNode('10');
	MinPlayers.appendChild(играчи);

var точност = xmlDoc.createTextNode('100%');
	Accuracy.appendChild(точност);


xmlDoc.save('qserver_dom.xml');