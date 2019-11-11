import React, {Component} from 'react';
import {
    View,
    Text,
    Image,
    ImageBackground
} from 'react-native';
import {WebView} from 'react-native-webview';
import {
    Icon,
    Button,
    Container,
    Header,
    Content,
    Left,
    Body,
    Card,
    CardItem,
    Right
} from 'native-base';

import headerStyle from '../styles/SideMenu.style';
import infoPageStyle from '../styles/InfoPage.style';
import GameStyle from '../styles/Game.style';
import {Fonts} from '../components/Fonts';


class GameScreen extends Component {
    render() {
        return (
           <Container>
                {/* Display the header, including access to the navigation menu */}
                <Header style={headerStyle.sectionHeadingStyle}>
                    <Left style={{flex: 1}}>
                        <Icon
                            style={headerStyle.navIconStyle}
                            name="ios-menu"
                            onPress={() => this.props.navigation.openDrawer()}
                        />
                    </Left>
                    <Body style={{flex:1}}/>
                    <Right style={{flex:1}} />
                </Header>
                {/* Informational content for 'Overview' */}
                <Content contentContainerStyle={infoPageStyle.content} style={infoPageStyle.pageStyle}>
                    <ImageBackground 
                        source={require('../assets/images/backgrounds/Background.jpg')}
                        style={{
                            width: '100%',
                            height: null,
                            flex: 1
                        }}
                    >
                        <Text style={GameStyle.pageHeadingText}>Awesome</Text>
                        <Text style={infoPageStyle.overflowPageHeadingText}>Game</Text>
                        <Text style={GameStyle.pageHeadingText}>
                           Hello </Text>
                        <Text style={GameStyle.pageBodyText}>
                            Welcome to our Capstone Game! Click on the 'Start Game' button to enter the game!
                        </Text>

                
                        
                       
        

                    </ImageBackground>
                </Content>
           </Container>
        );
    }
}

export default GameScreen;
