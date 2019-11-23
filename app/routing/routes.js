import HomeScreen from '../screens/HomeScreen';
import GameScreen from '../screens/GameScreen';
import GamePlayer from '../screens/GamePlayer';
import TimelineScreen from '../screens/TimelineScreen';
import SocialMediaScreen from '../screens/SocialMediaScreen';
import OverviewScreen from '../screens/OverviewScreen';
import AsteroidScreen from '../screens/AsteroidScreen';
import SpacecraftScreen from '../screens/SpacecraftScreen';
import ScienceScreen from '../screens/ScienceScreen';
import TeamScreen from '../screens/TeamScreen';
import { DrawerNavigator, DrawerItems, StackNavigator } from 'react-navigation';
import SideMenu from '../components/SideMenu'

//Adding a separate navigator for launching the unity game, it will contain the GameScreen (Portal) and the GamePlayer
const GameNavigator = StackNavigator({
	Portal: {
		screen: GameScreen
	},
	Player: {
		screen: GamePlayer
	},
},
	/*{
		headerMode: 'none',
		navigationOptions: {
			headerShown: false,
		}
	}*/
);

export default DrawerNavigator({
    Home: {
        screen: HomeScreen
    },
    Timeline: {
        screen: TimelineScreen
    },
    'Social Media': {
        screen: SocialMediaScreen
    },
    'Game': {
        screen: GameNavigator
    },
    Overview: {
        screen: OverviewScreen
    },
    'The Asteroid': {
        screen: AsteroidScreen
    },
    'The Spacecraft': {
        screen: SpacecraftScreen
    },
    'Instruments and Science': {
        screen: ScienceScreen
    },
    'The Team': {
        screen: TeamScreen
    }
}, {
    initialRouteName: 'Home', // Set diff for testing right now
    contentComponent: SideMenu,
    drawerOpenRoute: 'openDrawer',
    drawerCloseRoute: 'closeDrawer',
    drawerToggleRoute: 'toggleDrawer',
})

